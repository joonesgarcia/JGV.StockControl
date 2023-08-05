namespace JGV.StockControl.Library.DAL.Models
{
    public class Sell
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<SoldProduct> SoldProducts { get; set; }
    }
}
