using JGV.StockControl.Library.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.IRepository
{
    public interface IDebtsRepository
    {
        decimal GetTotalPaidByClient(int clientId);
        void BuildClientsDebts(int clientId = -1);
        List<ClientDebtViewModel> GetClientsDebtView(int clientId = -1);
    }
}
