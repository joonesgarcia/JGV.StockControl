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
    public struct SellOutputModel
    {
        private readonly decimal _totalPaidAmount { get; init; }
        private readonly decimal _initialDebtValue { get; init; }

        public SellOutputModel(int id, DateOnly date, Client client, decimal initialDebtValue, decimal totalPaidAmount, decimal profit, IEnumerable<SoldProductOutputModel> soldProductViews)
        {
            Id = id;
            Date = date;
            ClientName = client.Name;
            Profit = Tools.ExtractCurrencyString(profit);

            _initialDebtValue = initialDebtValue;
            _totalPaidAmount = totalPaidAmount;

            SoldProductViews = soldProductViews;
            Client = client;
        }
        public int Id { get; init; }
        [System.ComponentModel.DisplayName("Data")]
        public DateOnly Date { get; init; }
        [System.ComponentModel.DisplayName("Nome do cliente")]
        public string ClientName { get; init; }
        [System.ComponentModel.DisplayName("Dívida inicial")]
        public string InitialDebtValue
        {
            get
            {
                return Tools.ExtractCurrencyString(_initialDebtValue);
            }
        }
        [System.ComponentModel.DisplayName("Total pago")]
        public string TotalPaidAmount { get => Tools.ExtractCurrencyString(_totalPaidAmount); }
        [System.ComponentModel.DisplayName("Divida restante")]
        public string RemainingDebt
        {
            get
            {
                return Tools.ExtractCurrencyString(_initialDebtValue - _totalPaidAmount);
            }
        }
        [System.ComponentModel.DisplayName("Lucro")]
        public string Profit { get; init; }

        [Browsable(false)]
        public IEnumerable<SoldProductOutputModel> SoldProductViews { get; init; }
        [Browsable(false)]
        public Client Client { get; set; }

    }
}
