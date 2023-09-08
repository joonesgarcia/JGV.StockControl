namespace JGV.StockControl.Library.DAL.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
