using System.Globalization;


namespace JGV.StockControl.Library.BLL.ViewModel
{
    public struct SoldProductViewModel
    {
        public SoldProductViewModel(string productDescription, int quantity, decimal soldPrice)
        {
            ProductDescription = productDescription;
            Quantity = quantity;
            SoldPrice = Math.Round(soldPrice).ToString("C", new CultureInfo("pt-BR"));
        }
        [System.ComponentModel.DisplayName("Produto")]
        public string ProductDescription { get; set; }
        [System.ComponentModel.DisplayName("Valor vendido")]
        public string SoldPrice { get; set; }
        [System.ComponentModel.DisplayName("Quantidade")]
        public int Quantity { get; set; }

    }
}
