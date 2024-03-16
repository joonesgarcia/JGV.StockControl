using JGV.StockControl.Library.DAL.Models;
using System.ComponentModel;
using System.Globalization;


namespace JGV.StockControl.Library.BLL.ViewModel
{
    public class SoldProductOutputModel : INotifyPropertyChanged
    {
        private decimal soldPrice;
        private int quantity;
        private DateTime sellDate;
        public SoldProductOutputModel(string sellDate, int productId, string productDescription, int quantity, decimal soldPrice)
        { 
            this.SellDate = sellDate;
            this.ProductId = productId;
            this.ProductDescription = productDescription;
            this.Quantity = quantity;
            this.soldPrice = soldPrice;
            this.ExpectedSellPrice = soldPrice;
        }
        public static List<SoldProductOutputModel> GetViewFromSell(Sell sell)
            => sell.SoldProducts
                .Select(sp => new SoldProductOutputModel(sell.Date.ToShortDateString(), sp.ProductId, sp.Product.Description, sp.Quantity, sp.SoldPrice))
                .ToList();
        public SoldProductOutputModel()
        {}
        [DisplayName("Data da venda")]
        public string SellDate { 
            get
            {
                return sellDate.ToShortDateString();
            }
            set 
            {
                sellDate = DateTime.Parse(value);
            }
        }
        public int ProductId { get; set; }
        [System.ComponentModel.DisplayName("Produto")]
        public string ProductDescription { get; set; }
        [System.ComponentModel.DisplayName("Valor vendido")]
        public string SoldPrice { 
            get 
            { 
                return soldPrice.ToString("C", new CultureInfo("pt-BR")); 
            } 
            set 
            { 
                soldPrice = Tools.ExtractNumericValue(value); 
                NotifyPropertyChanged("SoldPrice");
            } 
        }
        [System.ComponentModel.DisplayName("Quantidade")]
        public int Quantity { get { return quantity; } 
            set 
            {
                quantity = value;
                NotifyPropertyChanged("Quantity");
            } 
        }
        [Browsable(false)]
        public decimal ExpectedSellPrice { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
