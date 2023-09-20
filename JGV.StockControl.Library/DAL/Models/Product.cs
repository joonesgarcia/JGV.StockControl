using System.ComponentModel.DataAnnotations;

namespace JGV.StockControl.Library.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BoughtQuantity { get; set; }
        public decimal Cost { get; set; }
        public decimal? SoldPrice { get; set; }
        public string? DiscountPromotion { get; set; }


        public virtual int? SellId { get; set; }
        public virtual Sell? Sell { get; set; }

    }

}
