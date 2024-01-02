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
    public partial class DebtDetailsForm : Form
    {
        public IUnitOfWork _unitOfWork { get; }
        private BindingList<SoldProductViewModel> _boughtProducts = new();
        public DebtDetailsForm(IUnitOfWork unitOfWork, List<SoldProductViewModel> boughtProducts)
        {
            _boughtProducts = new BindingList<SoldProductViewModel>(boughtProducts);
            _unitOfWork = unitOfWork;

            InitializeComponent();
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            debtDetailsGridView.AutoGenerateColumns = true;
            debtDetailsGridView.DataSource = _boughtProducts;
            debtDetailsGridView.Columns["ProductId"].Visible = false;

        }

    }
}
