using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public string? DiscountPromotion { get; set; }
    }
    public class SoldProduct
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal SoldPrice { get; set; }
        public virtual Sell Sell { get; set; }
        public virtual Product Product { get; set; }
    }
}
