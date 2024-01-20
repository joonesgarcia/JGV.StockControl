using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellDetailsForm : Form
    {
        private int _sellId;
        private BindingList<SoldProductViewModel> _soldProductsView;

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
            sellDetailsGridView.Columns["ProductId"].Visible = false;
            sellDetailsGridView.Columns["SellDate"].Visible = false;

            AddRemoveSoldProductButton();
        }
        private void AddRemoveSoldProductButton()
        {
            var deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "soldProductsViewDeleteButton";
            deleteButton.HeaderText = "";
            deleteButton.Text = "Remover";
            deleteButton.UseColumnTextForButtonValue = true;
            this.sellDetailsGridView.Columns.Add(deleteButton);
        }
        private void RefreshDividaRestantePanel()
        {
            Sell sell = _unitOfWork.SellRepository.GetSellById(_sellId);

            RefreshSoldProductsView(sell);
            RefreshDividaRestante(sell);

        }
        private void RefreshSoldProductsView(Sell sell)
         => _soldProductsView = new BindingList<SoldProductViewModel>(
                                    SoldProductViewModel.GetViewFromSell(sell));
        private void RefreshDividaRestante(Sell sell)
        {
            List<SoldProductViewModel> soldProductsView = SoldProductViewModel.GetViewFromSell(sell);

            labelDividaRestanteValor.Text = Tools.ExtractCurrencyString(soldProductsView.Sum(x => Tools.ExtractNumericValue(x.SoldPrice) * x.Quantity) - sell.TotalPaidAmount);
            SellDateValue.Text = sell.Date.ToShortDateString();
        }

        #region :: Events ::
        //private void ValidaValorAbatimento(object sender, EventArgs e)
        //{
        //    if (!decimal.TryParse(abaterDividaTextBox.Text, out decimal abater))
        //    {
        //        abaterDividaTextBox.Clear();
        //        abaterDividaTextBox.Text = "0";
        //    }
        //    else if (abater > Tools.ExtractNumericValue(labelDividaRestanteValor.Text))
        //        abaterDividaTextBox.Text = Tools.ExtractNumericValue(labelDividaRestanteValor.Text).ToString();
        //}
        //private void BotaoAbaterDivida_Click(object sender, EventArgs e)
        //{
        //    if (Tools.ExtractNumericValue(abaterDividaTextBox.Text) > 0)
        //    {
        //        decimal valorAbater = Convert.ToDecimal(Tools.ExtractNumericValue(abaterDividaTextBox.Text));

        //        _unitOfWork.SellRepository.DeduceDebtValue(_sellId, valorAbater);

        //        RefreshDividaRestantePanel();
        //    }
        //}
        void SoldProductsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == sellDetailsGridView.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == sellDetailsGridView.Columns["soldProductsViewDeleteButton"].Index)
            {
                Sell sell = _unitOfWork.SellRepository.GetSellById(_sellId);

                SoldProduct soldProduct = sell.SoldProducts
                    .FirstOrDefault(
                    p => p.Sell == sell &&
                    p.ProductId == Convert.ToInt32(sellDetailsGridView.Rows[e.RowIndex].Cells["ProductId"].Value))!;


                _unitOfWork.SellRepository.RemoveSoldProductFromSell(_sellId, soldProduct);
                _soldProductsView.RemoveAt(e.RowIndex);

                RefreshDividaRestante(sell);

                if (_soldProductsView.Count == 0)
                {
                    MessageBox.Show("Venda excluida! Não há produtos vendidos.");
                    this.Close();
                }
            }
        }
        #endregion

        private void cancellSellBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza? Não é possível desfazer essa ação.", "Cancelamento de venda", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _unitOfWork.SellRepository.CancelSell(_sellId);
                MessageBox.Show("Venda cancelada!");
                this.Close();
            }
        }
    }
}
