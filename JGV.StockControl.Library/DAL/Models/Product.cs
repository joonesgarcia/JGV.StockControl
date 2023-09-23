using System.ComponentModel.DataAnnotations;

namespace JGV.StockControl.Library.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BoughtQuantity { get; set; }
        public decimal Cost { get; set; }
        public string? DiscountPromotion { get; set; }

    }
    public class SoldProduct
    {
        public int ProductId { get; set; }
        public int SellId { get; set; }
        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sell Sell { get; set; }
    }

}
