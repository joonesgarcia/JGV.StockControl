using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockControlLocalDbContext _dbContext;
        public ProductRepository(StockControlLocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(ProductInputModel input)
        {
            Product product = new()
            {
                BoughtQuantity = input.BoughtQuantity,
                Cost = input.Cost,
                Description = input.Description,
                DiscountPromotion = input.DiscountPromotion,
                IsFromInitialInvestment = input.IsFromInitialInvestment,
                Price = input.Price,
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Product> GetAllProducts()
        => _dbContext.Products;
        public Product? GetProductById(int id)
        => _dbContext.Products.FirstOrDefault(p => p.Id == id);

        public int GetProductAvailableQuantity(Product product)
        => product.BoughtQuantity -
           _dbContext.SoldProducts
            .Where(sp => sp.Product == product)
            .Sum(sp => sp.Quantity);
    }
}
