using JGV.StockControl.Library.BLL.ViewModel;

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
        public ProductViewModel GetProductByDescription(string description)
        => GetAll().SingleOrDefault(p => description.Equals(p.Description));
    }
}
