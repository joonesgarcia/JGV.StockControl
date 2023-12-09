using JGV.StockControl.Library;
using JGV.StockControl.Library.BLL;
using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Builder;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System.ComponentModel;
using System.Data;
using System.Globalization;


namespace JGV.StockControl.DesktopApp.Forms
{
    public partial class AddSellForm : Form, INotifyPropertyChanged
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly BindingList<SoldProductViewModel> sellSoldProducts = new();
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
                NotifyPropertyChanged("TotalDebt");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        public AddSellForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void AddSellForm_Load(object sender, EventArgs e)
        {
            LoadClientComboBox();
            LoadAvailableProductsListView();
            ConfigureSoldProductsGrid();

            sellDebtValueText.DataBindings.Add(new Binding("Text", this, "TotalDebt"));
        }
        private void DownPaymentTextBoxOnlyNumbers(object sender, EventArgs e)
        {
            if (!int.TryParse(downPaymentTextBox.Text, out _))
            {
                downPaymentTextBox.Clear();
                downPaymentTextBox.Text = "0";
            }
        }
        private void LoadClientComboBox()
        {
            clientComboBox.DataSource = _unitOfWork.ClientRepository.GetAll();
            clientComboBox.DisplayMember = "Name";
            clientComboBox.ValueMember = "Id";
        }
        private void LoadAvailableProductsListView()
        {
            availableProductsListView.Columns.Add("Produto", 270, HorizontalAlignment.Left);
            availableProductsListView.Columns.Add("Disponível", 100, HorizontalAlignment.Center);

            var itens = _unitOfWork.ProductRepository.GetAll()
                .Where(p => p.AvailableQuantity > 0)
                .Select(pView => new ListViewItem(pView.Description) { SubItems = { pView.AvailableQuantity.ToString() } })
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
        private void AddSoldProductButton_Click(object sender, EventArgs e)
        {
            var selectedSoldProduct = availableProductsListView.FocusedItem;

            if (selectedSoldProduct != null)
            {
                var product = _unitOfWork.ProductRepository.GetProductViewByDescription(selectedSoldProduct.Text);
                int inputProductSoldQuantity = GetValidProductSoldQuantityFromInput(product);

                if (inputProductSoldQuantity > 0)
                {
                    var soldProductItem = ProductsService.CreateSoldProductItem(product, inputProductSoldQuantity);

                    if(sellSoldProducts.Any(x => x.ProductDescription.Equals(x.ProductDescription) && x.SoldPrice.Equals(soldProductItem.SoldPrice)))
                    {
                        var alreadyAddedProduct = sellSoldProducts.First(x => x.ProductDescription.Equals(x.ProductDescription) && x.SoldPrice.Equals(soldProductItem.SoldPrice));
                        alreadyAddedProduct.Quantity += soldProductItem.Quantity;

                        RefreshTotalDebtAndImpossibleSellMessage();
                        return;
                    }

                    sellSoldProducts.Add(soldProductItem);

                    RefreshTotalDebtAndImpossibleSellMessage();
                }
            }
        }
        private void RefreshTotalDebtTextValue()
        => TotalDebt = sellSoldProducts
                .Select(soldItem => Tools.ExtractNumericValue(soldItem.SoldPrice) * soldItem.Quantity)
                .Sum()
                .ToString("C", new CultureInfo("pt-BR"));

        private int GetValidProductSoldQuantityFromInput(ProductViewModel product)
        {
            int sellAlreadySoldProductQuantity = sellSoldProducts
                    .Where(p => p.ProductDescription == product.Description)
                    .Select(q => q.Quantity)
                    .Sum();

            return (int)soldProductQuantityInput.Value + sellAlreadySoldProductQuantity > product.AvailableQuantity ?
                    product.AvailableQuantity - sellAlreadySoldProductQuantity : (int)soldProductQuantityInput.Value;
        }
        private void AvailableProductsListView_ItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                soldProductQuantityInput.Maximum = decimal.Parse(e.Item.SubItems[1].Text);
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
        private void RemoveSoldProductButton_Click(object sender, EventArgs e)
        {
            if (SelectedSoldProductsGrid.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in SelectedSoldProductsGrid.SelectedCells)
                {
                    string soldProductName = (string)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[0].Value;
                    decimal soldProductValue = Tools.ExtractNumericValue((string)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[1].Value);
                    int soldProductQuantity = (int)SelectedSoldProductsGrid.Rows[cell.RowIndex].Cells[2].Value;
                    SoldProductViewModel? product = sellSoldProducts
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
        }
    }
}
