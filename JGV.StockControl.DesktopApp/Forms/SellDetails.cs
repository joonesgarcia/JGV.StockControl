using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System.Globalization;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellDetailsForm : Form
    {
        private int _sellId;
        private List<SoldProductViewModel> _soldProductsView;

        private readonly IUnitOfWork _unitOfWork;
        public SellDetailsForm(int sellId, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            _sellId = sellId;
        }
        private void SellDetailsForm_Load(object sender, EventArgs e)
        {
            RefreshDividaRestantePanel();
            InitializeGridView();
        }

        private void InitializeGridView()
        {
            sellDetailsGridView.AutoGenerateColumns = true;
            sellDetailsGridView.DataSource = _soldProductsView;
        }
        private void RefreshDividaRestantePanel()
        {
            Sell sell = _unitOfWork.SellRepository.GetSellById(_sellId);

            RefreshSoldProductsView(sell);
            RefreshDividaRestante(sell);

        }
        private void RefreshSoldProductsView(Sell sell)
         => _soldProductsView = SoldProductViewModel
                            .GetViewFromSell(sell);
        private void RefreshDividaRestante(Sell sell)
        {
            decimal debt = sell.InitialDebtAmount - sell.TotalPaidAmount;
            labelDividaRestanteValor.Text = debt.ToString("C", new CultureInfo("pt-BR"));
            if (debt == 0)
            {
                botaoAbaterDivida.Enabled = false;
                botaoAbaterDivida.BackColor = Color.Transparent;
            }
        }

        #region :: Events ::
        private void ValidaValorAbatimento(object sender, EventArgs e)
        {
            if (!decimal.TryParse(abaterDividaTextBox.Text, out decimal abater))
            {
                abaterDividaTextBox.Clear();
                abaterDividaTextBox.Text = "0";
            }
            else if (abater > Tools.ExtractNumericValue(labelDividaRestanteValor.Text))
                abaterDividaTextBox.Text = Tools.ExtractNumericValue(labelDividaRestanteValor.Text).ToString();
        }
        private void BotaoAbaterDivida_Click(object sender, EventArgs e)
        {
            if (Tools.ExtractNumericValue(abaterDividaTextBox.Text) > 0)
            {
                decimal valorAbater = Convert.ToDecimal(Tools.ExtractNumericValue(abaterDividaTextBox.Text));

                _unitOfWork.SellRepository.DeduceDebtValue(_sellId, valorAbater);

                RefreshDividaRestantePanel();
            }
        }
        #endregion

    }
}
