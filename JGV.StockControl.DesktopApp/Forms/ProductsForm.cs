using JGV.StockControl.Library.DAL.IRepository;
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
    public partial class ProductsForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            productsGridView.DefaultCellStyle.Font = new Font("Tahoma", 12);
            productsGridView.AutoGenerateColumns = true;
            productsGridView.DataSource = _unitOfWork.ProductRepository.GetAll();
        }
    }
}
