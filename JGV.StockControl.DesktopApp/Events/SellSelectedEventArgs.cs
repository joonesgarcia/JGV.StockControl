using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.DesktopApp.Events;

public class SellSelectedEventArgs : EventArgs
{
    public SellOutputModel SelectedSell { get; set; }
    public SellSelectedEventArgs(SellOutputModel selectedSell)
    {
        SelectedSell = selectedSell;
    }
}
