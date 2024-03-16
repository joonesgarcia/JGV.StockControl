using JGV.StockControl.Library.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.DesktopApp.Events
{
    public class DebtSelectedEventArgs : EventArgs
    {
        public ClientDebtOutputModel ClientDebt { get; set; }
        public DebtSelectedEventArgs(ClientDebtOutputModel clientDebt)
        {
            ClientDebt = clientDebt;
        }
    }
}
