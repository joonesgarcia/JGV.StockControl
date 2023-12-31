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
        private readonly decimal _totalPaidAmount { get; init; }
        private readonly decimal _initialDebtValue { get; init; }

        public SellViewModel(int id, DateOnly date, string clientName, decimal initialDebtValue, decimal totalPaidAmount, decimal profit, IEnumerable<SoldProductViewModel> soldProductViews)
        {
            Id = id;
            Date = date;
            ClientName = clientName;
            Profit = Tools.ExtractCurrencyString(profit);

            _initialDebtValue = initialDebtValue;
            _totalPaidAmount = totalPaidAmount;

            SoldProductViews = soldProductViews;
        }
        public int Id { get; init; }
        [System.ComponentModel.DisplayName("Data")]
        public DateOnly Date { get; init; }
        [System.ComponentModel.DisplayName("Nome do cliente")]
        public string ClientName { get; init; }
        [System.ComponentModel.DisplayName("Divida inicial")]
        public string InitialDebtValue
        {
            get
            {
                return Tools.ExtractCurrencyString(_initialDebtValue);
            }
        }
        [System.ComponentModel.DisplayName("Divida restante")]
        public string RemainingDebt
        {
            get
            {
                return Tools.ExtractCurrencyString(SoldProductViews.ToList()
                    .Sum(s => Tools.ExtractNumericValue(s.SoldPrice) * s.Quantity));
            }
        }
        [System.ComponentModel.DisplayName("Lucro")]
        public string Profit { get; init; }

        [Browsable(false)]
        public IEnumerable<SoldProductViewModel> SoldProductViews { get; init; }

    }
}
