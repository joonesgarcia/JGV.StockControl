using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL
{
    public static class ProductsService
    {
        public static SoldProductViewModel CreateSoldProductItem(ProductViewModel product, int quantity)
        {
            if (product.Equals(default(ProductViewModel)))
                return new SoldProductViewModel();

            SoldProductViewModel result = new ()
            {
                ProductDescription = product.Description,
                Quantity = quantity,
                SoldPrice = product.Price,
                ExpectedSellPrice = Tools.ExtractNumericValue(product.Price)
            };

            return result;
        }
    }
}
