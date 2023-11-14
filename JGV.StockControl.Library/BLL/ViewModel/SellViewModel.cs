using JGV.StockControl.Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL.ViewModel
{
    public struct SellViewModel
    {
        public SellViewModel(int id, DateOnly date, string clientName, decimal initialDebtValue, decimal totalPaidAmount, decimal profit, IEnumerable<SoldProductViewModel> soldProductViews)
        {
            Id = id;
            Date = date;
            ClientName = clientName;
            InitialDebtValue = initialDebtValue.ToString("C", new CultureInfo("pt-BR"));
            TotalPaidAmount = totalPaidAmount.ToString("C", new CultureInfo("pt-BR"));
            RemainingValue = initialDebtValue - totalPaidAmount;
            Profit = profit.ToString("C", new CultureInfo("pt-BR"));
            SoldProductViews = soldProductViews;
        }
        public int Id { get; init; }
        [System.ComponentModel.DisplayName("Data")]
        public DateOnly Date { get; init; }
        [System.ComponentModel.DisplayName("Nome do cliente")]
        public string ClientName { get; init; }
        [System.ComponentModel.DisplayName("Divida restante")]
        public decimal RemainingValue { get; init; }
        [System.ComponentModel.DisplayName("Divida inicial")]
        public string InitialDebtValue { get; init; }
        [System.ComponentModel.DisplayName("Divida quitada")]
        public string TotalPaidAmount { get; init; }
        [System.ComponentModel.DisplayName("Lucro")]
        public string Profit { get; init; }
        [Browsable(false)]
        public IEnumerable<SoldProductViewModel> SoldProductViews { get; init; }

    }
}
