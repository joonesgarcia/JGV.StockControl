using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();
        ProductViewModel GetProductViewByDescription(string description);
        Product? GetProductByDescription(string description);
    }
}
