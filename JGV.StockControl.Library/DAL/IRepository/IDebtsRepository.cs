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
    }
}
