using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL.ViewModel
{
    public struct ClientDebtOutputModel
    {
        private readonly decimal initialDebtValue;
        private readonly decimal remainingDebtValue;
        public int Id { get; set; }
        [System.ComponentModel.DisplayName("Nome do cliente")]
        public string ClientName { get; set; }
        [System.ComponentModel.DisplayName("Divida inicial")]
        public string InitialDebt { get => Tools.ExtractCurrencyString(initialDebtValue); }
        [System.ComponentModel.DisplayName("Divida restante")]
        public string RemainingDebtValue { get => Tools.ExtractCurrencyString(remainingDebtValue); }
        [System.ComponentModel.DisplayName("Data de cobrança")]
        public DateTime WillBePaidAt { get; set; }
        public string Comment { get; set; }

        [Browsable(false)]
        public IEnumerable<SellOutputModel> Purchases { get; set; } = new List<SellOutputModel>();
        [Browsable(false)]
        public int ClientId { get; set; }

        public ClientDebtOutputModel(int id, string clientName, int clientId, decimal initialDebtValue, decimal remainingDebtValue, string comment, DateTime willBePaidAt)
        {
            this.Id = id;   
            this.ClientName = clientName;
            this.initialDebtValue = initialDebtValue;
            this.remainingDebtValue = remainingDebtValue;
            this.Comment = comment;
            this.WillBePaidAt = willBePaidAt;
            this.ClientId = clientId;   
        }

    }
}
