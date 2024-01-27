using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using System.ComponentModel;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class DebtDetailsForm : Form
    {
        public IUnitOfWork _unitOfWork { get; }
        private BindingList<SellViewModel> _purchases = new();
        private readonly ClientDebtViewModel _clientDebt;

        public DebtDetailsForm(IUnitOfWork unitOfWork, ClientDebtViewModel clientDebt)
        {
            _unitOfWork = unitOfWork;
            _clientDebt = clientDebt;

            _purchases = new BindingList<SellViewModel>(clientDebt.Purchases.OrderByDescending(d => d.Date).ToList());

            InitializeComponent();
            InitializeGridView();
            RefreshDividaRestantePanel();
        }
        private void InitializeGridView()
        {
            debtDetailsGridView.AutoGenerateColumns = true;
            debtDetailsGridView.DataSource = _purchases;
            debtDetailsGridView.Columns["Profit"].Visible = false;
            debtDetailsGridView.Columns["ClientName"].Visible = false;
        }

        private void RefreshDividaRestantePanel()
        {
            clientValue.Text = _clientDebt.ClientName;
            dividaRestanteValue.Text = _clientDebt.RemainingDebtValue;
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
        private void ValidaValorAbatimento(object sender, EventArgs e)
        {
            if (!decimal.TryParse(abaterDividaTextBox.Text, out decimal abater) || abater < 0)
            {
                abaterDividaTextBox.Clear();
                abaterDividaTextBox.Text = "0";
            }
            else if (abater > Tools.ExtractNumericValue(dividaRestanteValue.Text))
                abaterDividaTextBox.Text = Tools.ExtractNumericValue(dividaRestanteValue.Text).ToString();
        }
        private void BotaoAbaterDivida_Click(object sender, EventArgs e)
        {
            if (Tools.ExtractNumericValue(abaterDividaTextBox.Text) > 0)
            {
                decimal valorAbater = Convert.ToDecimal(Tools.ExtractNumericValue(abaterDividaTextBox.Text));

                // _unitOfWork.SellRepository.DeduceDebtValue(_sellId, valorAbater);

                // RefreshDividaRestantePanel();
            }
        }
    }
}
