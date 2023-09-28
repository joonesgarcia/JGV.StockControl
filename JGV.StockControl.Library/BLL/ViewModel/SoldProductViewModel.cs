using System.Globalization;


namespace JGV.StockControl.Library.BLL.ViewModel
{
    public struct SoldProductViewModel
    {
        public SoldProductViewModel(string productDescription, decimal productCost, int quantity, decimal soldPrice)
        {
            ProductDescription = productDescription;
            ProductCost = Math.Round(productCost).ToString("C", new CultureInfo("pt-BR"));
            Quantity = quantity;
            SoldPrice = Math.Round(soldPrice).ToString("C", new CultureInfo("pt-BR"));
        }
        [System.ComponentModel.DisplayName("Produto")]
        public string ProductDescription { get; set; }
        [System.ComponentModel.DisplayName("Preço pago")]
        public string ProductCost { get; set; }
        [System.ComponentModel.DisplayName("Valor vendido")]
        public string SoldPrice { get; set; }
        [System.ComponentModel.DisplayName("Quantidade")]
        public int Quantity { get; set; }

    }
}
