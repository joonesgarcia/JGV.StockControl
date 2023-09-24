using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository;
public interface ISellRepository
{
    public List<SellViewModel> GetAll();
    public void AddSell(SellInputModel model);
    public void CancelSell(int sellId);
}
