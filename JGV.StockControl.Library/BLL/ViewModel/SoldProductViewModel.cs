using System.ComponentModel;
using System.Globalization;


namespace JGV.StockControl.Library.BLL.ViewModel
{
    public class SoldProductViewModel : INotifyPropertyChanged
    {
        private string productDescription;
        private string soldPrice;
        private int quantity;
        public SoldProductViewModel(string productDescription, int quantity, decimal soldPrice)
        {
            ProductDescription = productDescription;
            Quantity = quantity;
            SoldPrice = Math.Round(soldPrice).ToString("C", new CultureInfo("pt-BR"));
        }
        public SoldProductViewModel()
        {

        }

        [System.ComponentModel.DisplayName("Produto")]
        public string ProductDescription { get => productDescription; set => productDescription = value; }
        [System.ComponentModel.DisplayName("Valor vendido")]
        public string SoldPrice { get { return soldPrice; } set { soldPrice = value; NotifyPropertyChanged("SoldPrice"); } }
        [System.ComponentModel.DisplayName("Quantidade")]
        public int Quantity { get { return quantity; } set { quantity = value; NotifyPropertyChanged("Quantity"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
    }
}
