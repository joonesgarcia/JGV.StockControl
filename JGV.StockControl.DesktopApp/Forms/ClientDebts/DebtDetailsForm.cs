using JGV.StockControl.DesktopApp.Events;
using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using JGV.StockControl.Library.Services;
using System.ComponentModel;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class DebtDetailsForm : Form
    {
        public IUnitOfWork _unitOfWork { get; }

        private ClientDebtOutputModel _clientDebt;
        private BindingList<SellOutputModel> _purchases;

        private readonly SellDetailsForm _sellDetailsForm;
        private readonly SellsService _sellsService;

        public event EventHandler<SellSelectedEventArgs> SellSelected;
        public DebtDetailsForm(IUnitOfWork unitOfWork, SellDetailsForm sellDetailsForm, SellsService sellsService)
        {
            _unitOfWork = unitOfWork;

            _sellDetailsForm = sellDetailsForm;
            SellSelected += _sellDetailsForm.HandleSellSelected;

            _sellsService = sellsService;

            _purchases = new BindingList<SellOutputModel>(_clientDebt.Purchases.OrderByDescending(d => d.Date).ToList());

            InitializeComponent();
            InitializeGridView();
            RefreshDividaRestantePanel();
        }

        private void OnSellSelected(SellOutputModel sell)
        => SellSelected.Invoke(this, new SellSelectedEventArgs(sell));

        public void HandleDebtSelected(object sender, DebtSelectedEventArgs e)
        {
            _purchases.Clear();

            _clientDebt = e.ClientDebt;
            _purchases = new BindingList<SellOutputModel>(e.ClientDebt.Purchases.ToList());
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
            _clientDebt.Purchases = _sellsService.GetAllSellsView(_clientDebt.ClientId);

            _purchases = new BindingList<SellOutputModel>(_clientDebt.Purchases.OrderByDescending(d => d.Date).ToList());
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
                Sell? sell = _unitOfWork.SellRepository.GetSellById(sellId);

                if (sell != null)
                {
                    OnSellSelected(_sellsService.GetSellView(sell));
                    _sellDetailsForm.Show();
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
                bool deduced = false;

                while (valorAbater > 0)
                {
                    SellOutputModel ultimaCompraDevedora = _purchases.Single(p => p.Id == GetLastSellIdWithDebt());
                    decimal valorAbativelUltimaCompraDevedora = Tools.ExtractNumericValue(ultimaCompraDevedora.RemainingDebt);

                    if (valorAbater > valorAbativelUltimaCompraDevedora)
                        deduced = _unitOfWork.SellRepository.DeduceDebtFromSell(ultimaCompraDevedora.Id, valorAbativelUltimaCompraDevedora);
                    else
                        deduced = _unitOfWork.SellRepository.DeduceDebtFromSell(ultimaCompraDevedora.Id, valorAbater);

                    valorAbater -= valorAbativelUltimaCompraDevedora;
                }
                RefreshClientDebt();

                if (deduced)
                    MessageBox.Show("Valor abatido!");
                else
                    MessageBox.Show("Erro durante abatimento");
            }
        }
        private int GetLastSellIdWithDebt()
        => _purchases.Last(x => Tools.ExtractNumericValue(x.RemainingDebt) > 0).Id;

    }
}
