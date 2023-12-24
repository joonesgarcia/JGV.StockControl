using JGV.StockControl.Library.DAL.Models;
using System.ComponentModel;
using System.Globalization;


namespace JGV.StockControl.Library.BLL.ViewModel
{
    public class SoldProductViewModel : INotifyPropertyChanged
    {
        private decimal soldPrice;
        private int quantity;
        public SoldProductViewModel(int productId, string productDescription, int quantity, decimal soldPrice)
        {
            this.ProductId = productId;
            this.ProductDescription = productDescription;
            this.Quantity = quantity;
            this.soldPrice = soldPrice;
            this.ExpectedSellPrice = soldPrice;
        }
        public static List<SoldProductViewModel> GetViewFromSell(Sell sell)
            => sell.SoldProducts
                .Select(sp => new SoldProductViewModel(sp.ProductId, sp.Product.Description, sp.Quantity, sp.SoldPrice))
                .ToList();
        public SoldProductViewModel()
        {}
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
