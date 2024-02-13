using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL
{
    public class ProductsService
    {
        private readonly ProductRepository _productRepository;

        public ProductsService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public static SoldProductViewModel CreateSoldProductItem(ProductViewModel product, int quantity)
        {
            if (product.Equals(default(ProductViewModel)))
                return new SoldProductViewModel();

            SoldProductViewModel result = new()
            {
                ProductDescription = product.Description,
                Quantity = quantity,
                SoldPrice = product.Price,
                ExpectedSellPrice = Tools.ExtractNumericValue(product.Price)
            };

            return result;
        }

        public IEnumerable<ProductViewModel> GetProductsView()
        => _productRepository.GetAllProducts()
        .Select(x => GetProductView(x));



        private ProductViewModel GetProductView(Product product)
        {
            ProductViewModel productView = new()
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
    }
}
