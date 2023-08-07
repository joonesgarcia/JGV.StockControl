using JGV.StockControl.Library.DAL.ViewModel;


namespace JGV.StockControl.Library.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockControlDbContext _dbContext;

        public ProductRepository(StockControlDbContext dbContext)
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
                p.DiscountPromotion))
            .ToList();              
    }
}
