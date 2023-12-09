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
        public List<ProductViewModel> GetAll()
        => _dbContext.Products
            .Select(p => new ProductViewModel(
                p.Description,
                p.Cost,
                p.Price,
                p.BoughtQuantity - _dbContext.SoldProducts.Where(s => s.Product == p)
                                                          .Select(p => p.Quantity)
                                                          .Sum(),
                p.DiscountPromotion,
                p.IsFromInitialInvestment))
            .AsEnumerable()
            .OrderByDescending(quantity => quantity.AvailableQuantity)
            .ToList();
        public ProductViewModel GetProductViewByDescription(string description)
        => GetAll().SingleOrDefault(p => description.Equals(p.Description));
        public Product? GetProductByDescription(string description)
        {
            if (description == null) return null;

            bool isFromInitialInvestment = false;
            string productDescription = description.ToUpperInvariant();

            if(productDescription.Last() == '*')
            {
                isFromInitialInvestment = true;
                productDescription = productDescription[..^1];
            }        
            return _dbContext.Products
                .AsEnumerable()
                .FirstOrDefault(p => 
                    p.Description.ToUpperInvariant() ==  productDescription &&
                    p.IsFromInitialInvestment == isFromInitialInvestment);
        }

    }
}
