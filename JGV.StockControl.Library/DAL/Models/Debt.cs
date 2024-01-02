using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime WillBePaidIn { get; set; }
        public decimal TotalPaid { get; set; }
        public string Comment { get; set; }
        public virtual Client Client { get; set; }
    }
}
