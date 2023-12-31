﻿namespace JGV.StockControl.Library.DAL.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal InitialDebtAmount { get; set; }

        public virtual Client Client { get; set; } 
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }

    }
}
