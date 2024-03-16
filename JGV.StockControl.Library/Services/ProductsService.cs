using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;

namespace JGV.StockControl.Library.Services;

public class ProductsService
{
    private readonly IProductRepository _productRepository;

    public ProductsService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public IEnumerable<ProductOutputModel> GetProductsView()
    => _productRepository.GetAllProducts()
    .Select(x => GetProductView(x.Id));
    public ProductOutputModel GetProductView(int productId)
    {
        Product product = _productRepository.GetProductById(productId) ?? throw new ArgumentException("Invalid productId");

        ProductOutputModel productView = new()
        {
            ProductId = product.Id,
            Description = product.Description,
            DiscountPromotion = product.DiscountPromotion,
            IsFromInitialInvestment = product.IsFromInitialInvestment,
            Cost = Tools.ExtractCurrencyString(product.Cost),
            Price = Tools.ExtractCurrencyString(product.Price),
            AvailableQuantity = _productRepository.GetProductAvailableQuantity(product)
        };
        return productView;
    }
    public static SoldProductOutputModel CreateSoldProductItem(ProductOutputModel product, int quantity)
    {
        if (quantity <= 0) throw new ArgumentException("Cannot CreateSoldProductItem for quantity <= 0");

        SoldProductOutputModel result = new()
        {
            ProductDescription = product.Description,
            Quantity = quantity,
            SoldPrice = product.Price,
            ExpectedSellPrice = Tools.ExtractNumericValue(product.Price)
        };

        return result;
    }
}
