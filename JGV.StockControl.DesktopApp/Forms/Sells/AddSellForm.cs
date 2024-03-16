using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Builder;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.Services;
using System.ComponentModel;
using System.Data;
using System.Globalization;


namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class AddSellForm : Form, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ClientsService _clientsService;
        private readonly ProductsService _productsService;

        private readonly BindingList<SoldProductOutputModel> sellSoldProducts = new();

        private decimal totalDebtValue;
        public string TotalDebt
        {
            get
            {
                return totalDebtValue.ToString("C", new CultureInfo("pt-BR"));
            }
            set
            {
                totalDebtValue = Tools.ExtractNumericValue(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(("TotalDebt")));
            }
        }
        public AddSellForm(IUnitOfWork unitOfWork, ClientsService clientsService, ProductsService productsService)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;

            _clientsService = clientsService;
            _productsService = productsService;
        }

        #region ::: Load Form :::
        private void AddSellForm_Load(object sender, EventArgs e)
        {
            LoadClientComboBox();
            LoadAvailableProductsListView();
            ConfigureSoldProductsGrid();

            sellDebtValueText.DataBindings.Add(new Binding("Text", this, "TotalDebt"));
        }

        private void LoadClientComboBox()
        {
            clientComboBox.DataSource = _clientsService.GetAllClients();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
        }
        private void LoadAvailableProductsListView()
        {
            availableProductsListView.Columns.Add("Produto", 270, HorizontalAlignment.Left);
            availableProductsListView.Columns.Add("Disponível", 100, HorizontalAlignment.Center);

            var itens = _productsService.GetProductsView()
                .Where(p => p.AvailableQuantity > 0)
                .Select(pView => new ListViewItem(pView.Description) { SubItems = { pView.ProductId.ToString() ,pView.AvailableQuantity.ToString() } })
                .ToArray();

            availableProductsListView.Items.AddRange(itens);
        }
        private void ConfigureSoldProductsGrid()
        {
            SelectedSoldProductsGrid.DataSource = sellSoldProducts;
            SelectedSoldProductsGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            SelectedSoldProductsGrid.Columns["ProductDescription"].ReadOnly = true;
            SelectedSoldProductsGrid.Columns["Quantity"].ReadOnly = true;
        }

        #endregion
        #region ::: Form Events :::
        private void AddSoldProductButton_Click(object sender, EventArgs e)
        {
            var selectedSoldProduct = availableProductsListView.FocusedItem;

            if (selectedSoldProduct != null)
            {
                int productId = Convert.ToInt32(selectedSoldProduct.SubItems[0].Text);

                var productView = _productsService.GetProductView(productId);
                int inputProductSoldQuantity = GetValidProductSoldQuantityFromInput(productView);

                if (inputProductSoldQuantity > 0)
                {
                    var soldProductItem = ProductsService.CreateSoldProductItem(productView, inputProductSoldQuantity);

                    if (sellSoldProducts.Any(sp => sp.ProductId == soldProductItem.ProductId))
                    {
                        var alreadyAddedProduct = sellSoldProducts.First(sp => sp.ProductId == soldProductItem.ProductId);
                        alreadyAddedProduct.Quantity += soldProductItem.Quantity;

                        RefreshTotalDebtAndImpossibleSellMessage();
                        return;
                    }

                    sellSoldProducts.Add(soldProductItem);

                    RefreshTotalDebtAndImpossibleSellMessage();
                }
            }
        }
        private void RemoveSoldProductButton_Click(object sender, EventArgs e)
        {
            if (SelectedSoldProductsGrid.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in SelectedSoldProductsGrid.SelectedCells)
                {
                    string soldProductName = (string)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[1].Value;
                    decimal soldProductValue = Tools.ExtractNumericValue((string)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[1].Value);
                    int soldProductQuantity = (int)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[2].Value;

                    SoldProductOutputModel? product = sellSoldProducts
                        .First(x =>
                        soldProductName.Equals(x.ProductDescription) &&
                        soldProductValue.Equals(Tools.ExtractNumericValue(x.SoldPrice)) &&
                        soldProductQuantity.Equals(x.Quantity));

                    if (product != null)
                        sellSoldProducts.Remove(product);
                }
                RefreshTotalDebtAndImpossibleSellMessage();
            }
        }
        private void AddSellButton_Click(object sender, EventArgs e)
        {
            if (sellSoldProducts.Any())
            {
                var client = (Client)clientComboBox.SelectedItem;
                if (client != null)
                {
                    var sellDate = sellDateInput.Value;
                    var downPayment = decimal.Parse(downPaymentTextBox.Text.ToString());

                    Sell newSell = new SellBuilder(_unitOfWork)
                        .CreateSell()
                        .WithSoldProducts(sellSoldProducts)
                        .AtDate(sellDate)
                        .ForClient(client)
                        .WithDownPayment(downPayment)
                        .Build();

                    _unitOfWork.SellRepository.AddSell(newSell);
                    MessageBox.Show("Venda adicionada!");

                    this.Close();
                }
                else
                    MessageBox.Show("Cliente inválido!");
            }
        }

        private void RefreshTotalDebtAndImpossibleSellMessage()
        {
            RefreshTotalDebtTextValue();

            decimal totalExpectedValue = sellSoldProducts
                .Select(soldItem => soldItem.ExpectedSellPrice)
                .Sum();

            decimal totalSoldPriceValue = sellSoldProducts
                .Select(soldItem => Tools.ExtractNumericValue(soldItem.SoldPrice))
                .Sum();

            if (totalExpectedValue == 0)
                return;

            decimal discount = ((totalExpectedValue - totalSoldPriceValue) / totalExpectedValue) * 100;
            if (discount > 0)
            {
                discountTextValue.Text = Math.Round(discount).ToString() + " % OFF";
                if (discount > 15)
                {
                    this.Text = "VENDA IMPOSSIVEL";
                    discountTextValue.ForeColor = Color.Red;
                    discountTextValue.BackColor = Color.White;
                    impossibleSellLable.Text = this.Text;
                }
                else
                {
                    this.Text = "Cadastro de venda";
                    impossibleSellLable.Text = "";

                }
            }
        }
        private void RefreshTotalDebtTextValue()
        => TotalDebt = sellSoldProducts
            .Select(soldItem => Tools.ExtractNumericValue(soldItem.SoldPrice) * soldItem.Quantity)
            .Sum()
            .ToString("C", new CultureInfo("pt-BR"));

        #endregion
        #region ::: Validations :::
        private int GetValidProductSoldQuantityFromInput(ProductOutputModel product)
        {
            int alreadySoldProductQuantity = sellSoldProducts
                    .Where(p => p.ProductId == product.ProductId)
                    .Select(q => q.Quantity)
                    .Sum();

            return (int)soldProductQuantityInput.Value + alreadySoldProductQuantity > product.AvailableQuantity ?
                    product.AvailableQuantity - alreadySoldProductQuantity : (int)soldProductQuantityInput.Value;
        }
        private void DownPaymentTextBoxOnlyNumbers(object sender, EventArgs e)
        {
            if (!int.TryParse(downPaymentTextBox.Text, out _))
            {
                downPaymentTextBox.Clear();
                downPaymentTextBox.Text = "0";
            }
        }
        private void AvailableProductsListView_ItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                soldProductQuantityInput.Maximum = decimal.Parse(e.Item.SubItems[1].Text);
            }
        }
        #endregion
    }
}
