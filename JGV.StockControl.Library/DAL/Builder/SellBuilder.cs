using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Builder
{
    public class SellBuilder
    {
        private readonly IUnitOfWork _unitOfWork;
        private Sell _sell;

        public SellBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public SellBuilder CreateSell()
        {
            _sell = new Sell();  
            _sell.Id = _unitOfWork.SellRepository.GetNextSellId();
            return this;
        }
        public SellBuilder WithSoldProducts(IEnumerable<SoldProductViewModel> soldProductViews) 
        {
            List<SoldProduct> soldProducts = new();
            decimal debt = 0;

            foreach (var productView in soldProductViews)
            {
                Product? product = _unitOfWork.ProductRepository.GetProductById(productView.ProductId) ?? 
                    throw new NullReferenceException($"Product {productView.ProductDescription} not found");

                SoldProduct soldProduct = new SoldProduct()
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = productView.Quantity,
                    SoldPrice = Tools.ExtractNumericValue(productView.SoldPrice),
                    Sell = _sell,
                    SellId = _sell.Id
                };
                soldProducts.Add(soldProduct);
                debt += soldProduct.Quantity * soldProduct.SoldPrice;
            }
            _sell.InitialDebtAmount = debt;
            _sell.SoldProducts = soldProducts;
            return this;
        }
        public SellBuilder AtDate(DateTime date)
        {
            _sell.Date = date;
            return this;
        }
        public SellBuilder ForClient(Client client)
        {
            client.Orders.Add(_sell);
            _sell.Client = client;
            _sell.ClientId = client.Id;
            return this;
        }
        public SellBuilder WithDownPayment(decimal amount)
        {
            _sell.TotalPaidAmount = amount;
            return this;
        }
        public Sell Build()
        => _sell;

    }
}
