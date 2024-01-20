using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using System.ComponentModel;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class DebtDetailsForm : Form
    {
        public IUnitOfWork _unitOfWork { get; }
        private BindingList<SellViewModel> _purchases = new();
        public DebtDetailsForm(IUnitOfWork unitOfWork, List<SellViewModel> purchases)
        {
            _purchases = new BindingList<SellViewModel>(purchases);
            _unitOfWork = unitOfWork;

            InitializeComponent();
            InitializeGridView();
        }
        private void InitializeGridView()
        {
            debtDetailsGridView.AutoGenerateColumns = true;
            debtDetailsGridView.DataSource = _purchases;
            debtDetailsGridView.Columns["Profit"].Visible = false;
        }
        private void DebtDetailsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var sellId = Convert.ToInt32(debtDetailsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (sellId > 0)
                {
                    SellDetailsForm sellDetailsForm = new(sellId, _unitOfWork);
                    sellDetailsForm.Show();
                }
            }
        }
    }
}
