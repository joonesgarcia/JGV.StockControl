using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            .Select(p => new ProductViewModel(p.Description, p.Cost, p.Price, p.AvailableQuantity, p.DiscountPromotion))
            .ToList();
           
        
    }
}
