using JGV.StockControl.DesktopApp.Events;
using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System.ComponentModel;

namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class SellDetailsForm : Form
    {
        private SellOutputModel _sellView;
        private BindingList<SoldProductOutputModel> _soldProductsView;

        private readonly IUnitOfWork _unitOfWork;
        public SellDetailsForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void InitializeGridView()
        {
            sellDetailsGridView.AutoGenerateColumns = true;
            sellDetailsGridView.DataSource = _soldProductsView;
            sellDetailsGridView.Columns["ProductId"].Visible = false;
            sellDetailsGridView.Columns["SellDate"].Visible = false;

            ConfigureRemoveSoldProductButton();
        }
        private void ConfigureRemoveSoldProductButton()
        {
            var deleteButton = new DataGridViewButtonColumn
            {
                Name = "soldProductsViewDeleteButton",
                HeaderText = "",
                Text = "Remover",
                UseColumnTextForButtonValue = true
            };
            this.sellDetailsGridView.Columns.Add(deleteButton);
        }
        private void RefreshDividaRestantePanel()
        {
            RefreshSoldProductsView();
            RefreshDividaRestanteText();
        }
        private void RefreshSoldProductsView()
         => _soldProductsView = new BindingList<SoldProductOutputModel>(_sellView.SoldProductViews.ToList());
        private void RefreshDividaRestanteText()
        {
            labelDividaRestanteValor.Text = Tools.ExtractCurrencyString(_soldProductsView.Sum(x => Tools.ExtractNumericValue(x.SoldPrice) * x.Quantity) - Tools.ExtractNumericValue(_sellView.TotalPaidAmount));
            SellDateValue.Text = _sellView.Date.ToShortDateString();
        }

        #region :: Events ::

        public void HandleSellSelected(object sender, SellSelectedEventArgs e)
        {
            _sellView = e.SelectedSell;
            _soldProductsView = new(_sellView.SoldProductViews.ToList());

            InitializeGridView();
            RefreshDividaRestantePanel();
        }

        void SoldProductsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if click is on new row or header row
            if (e.RowIndex == sellDetailsGridView.NewRowIndex || e.RowIndex < 0)
                return;

            //Check if click is on specific column 
            if (e.ColumnIndex == sellDetailsGridView.Columns["soldProductsViewDeleteButton"].Index)
            {
                Sell sell = _unitOfWork.SellRepository.GetSellById(_sellView.Id);

                SoldProduct soldProduct = sell.SoldProducts
                    .FirstOrDefault(
                    p => 
                    p.Sell == sell &&
                    p.ProductId == Convert.ToInt32(sellDetailsGridView.Rows[e.RowIndex].Cells["ProductId"].Value))!;


                _unitOfWork.SellRepository.RemoveSoldProductFromSell(_sellView.Id, soldProduct);
                _soldProductsView.RemoveAt(e.RowIndex);

                RefreshDividaRestanteText();

                if (_soldProductsView.Count == 0)
                {
                    MessageBox.Show("Venda excluida! Não há produtos vendidos.");
                    this.Close();
                }
            }
        }
        private void CancellSellBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza? Não é possível desfazer essa ação.", "Cancelamento de venda", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _unitOfWork.SellRepository.CancelSell(_sellView.Id);
                MessageBox.Show("Venda cancelada!");
                this.Close();
            }
        }
        #endregion
    }
}
