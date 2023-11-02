using JGV.StockControl.Library.BLL;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class AddSellForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly BindingList<SoldProductViewModel> sellSoldProducts = new();
        public AddSellForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void AddSellForm_Load(object sender, EventArgs e)
        {
            LoadClientComboBox();
            LoadSoldProductsListSeletor();
            ConfigureSoldProductsGrid();
        }
        private void DownPaymentTextBoxOnlyNumbers(object sender, EventArgs e)
        {
            if (!int.TryParse(downPaymentTextBox.Text, out _))
            {
                downPaymentTextBox.Clear();
            }
        }
        private void LoadClientComboBox()
        {
            clientComboBox.DataSource = _unitOfWork.ClientRepository.GetAll();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
        }
        private void LoadSoldProductsListSeletor()
        {
            soldProductsListSeletor.Items.AddRange(
                _unitOfWork.ProductRepository.GetAll()
                .Where(p => p.AvailableQuantity > 0)
                .Select(listViewItem => listViewItem.Description)
                .ToArray()
            );
        }
        private void ConfigureSoldProductsGrid()
        {
            SelectedSoldProductsGrid.DataSource = sellSoldProducts;
        }

        private void AddSoldProductButton_Click(object sender, EventArgs e)
        {
            var selectedSoldProduct = soldProductsListSeletor.SelectedItem;
            if (selectedSoldProduct != null)
            {
                var product = _unitOfWork.ProductRepository.GetProductByDescription((string)selectedSoldProduct);
                var soldProduct = ProductsService.CreateSoldProductItem(product, (int)soldProductQuantityInput.Value);

                sellSoldProducts.Add(soldProduct);
            }
        }
    }
}
