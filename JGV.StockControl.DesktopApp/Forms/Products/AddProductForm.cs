using JGV.StockControl.Library.BLL;
using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.Repository;

namespace JGV.StockControl.DesktopApp.Forms.Products;

public partial class AddProductForm : Form
{
    private readonly IProductRepository _productRepository;

    public event EventHandler ProductAdded;
    public AddProductForm(IProductRepository productRepository)
    {
        InitializeComponent();

        _productRepository = productRepository;
    }

    private void insertBtn_Click(object sender, EventArgs e)
    {
        ProductInputModel input = new(
            descriptionInput.Text,
            Convert.ToInt16(quantityInput.Value),
            Convert.ToDecimal(costInput.Text),
            Convert.ToDecimal(priceInput.Text),
            promotionInput.Text
            );

        _productRepository.AddProduct(input);
        ProductAdded.Invoke(this, EventArgs.Empty);
    }
}
