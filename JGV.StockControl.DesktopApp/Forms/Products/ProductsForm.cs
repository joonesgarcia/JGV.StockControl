using JGV.StockControl.DesktopApp.Forms.Products;
using JGV.StockControl.Library.Services;

namespace JGV.StockControl.DesktopApp.Forms;

public partial class ProductsForm : Form
{
    private readonly ProductsService _productService;
    private readonly AddProductForm _addProductForm;

    public ProductsForm(ProductsService productService, AddProductForm addProductForm)
    {
        InitializeComponent();

        _productService = productService;
        _addProductForm = addProductForm;
    }

    private void ProductsForm_Load(object sender, EventArgs e)
    {
        InitializeGridView();
    }
    private void InitializeGridView()
    {
        productsGridView.AutoGenerateColumns = true;
        RefreshGridStockView();
    }
    private void RefreshGridStockView()
        => productsGridView.DataSource = _productService.GetProductsView().ToList();

    private void addProductBtn_Click(object sender, EventArgs e)
    {
        _addProductForm.ShowDialog();
        _addProductForm.ProductAdded += OnProductAdded;
    }

    private void OnProductAdded(object sender, EventArgs e)
        => RefreshGridStockView();
}
