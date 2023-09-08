using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL.ViewModel
{
    public struct SellViewModel
    {
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public string ClientName { get; init; }
        public decimal InitialDebtValue { get; init; }
        public decimal TotalPaidAmount { get; init; }
        public decimal RemainingValue
        => InitialDebtValue - TotalPaidAmount;
        public decimal Profit { get; init; }

    }
}
