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
        private ClientDebtViewModel _clientDebt;

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

        private void RefreshClientDebt()
        {
            _clientDebt = _unitOfWork.DebtsRepository.GetClientsDebtView(_clientDebt.ClientId).Single();

            _purchases = new BindingList<SellViewModel>(_clientDebt.Purchases.OrderByDescending(d => d.Date).ToList());
            debtDetailsGridView.DataSource = _purchases;

            RefreshDividaRestantePanel();
        }

        private void RefreshDividaRestantePanel()
        {
            clientNameValue.Text = _clientDebt.ClientName;
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
        private void abaterDividaBtn_Click(object sender, EventArgs e)
        {
            if (Tools.ExtractNumericValue(abaterDividaTextBox.Text) > 0)
            {
                decimal valorAbater = Tools.ExtractNumericValue(abaterDividaTextBox.Text);

                while (valorAbater > 0)
                {
                    SellViewModel ultimaCompraDevedora = _purchases.Single(p => p.Id == GetLastSellIdWithDebt());
                    decimal valorAbativelUltimaCompraDevedora = Tools.ExtractNumericValue(ultimaCompraDevedora.RemainingDebt);

                    if (valorAbater > valorAbativelUltimaCompraDevedora)
                        _unitOfWork.SellRepository.DeduceDebtValue(ultimaCompraDevedora.Id, valorAbativelUltimaCompraDevedora);                   
                    else
                        _unitOfWork.SellRepository.DeduceDebtValue(ultimaCompraDevedora.Id, valorAbater);

                    valorAbater -= valorAbativelUltimaCompraDevedora;
                    RefreshClientDebt();
                }
                MessageBox.Show("Valor abatido!");
            }
        }
        private int GetLastSellIdWithDebt()
        => _purchases.Last(x => Tools.ExtractNumericValue(x.RemainingDebt) > 0).Id;
        
    }
}
