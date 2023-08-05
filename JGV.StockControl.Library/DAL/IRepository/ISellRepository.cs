using JGV.StockControl.Library.DAL.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository;
public interface ISellRepository
{
    public void AddSell(SellInputModel model);
    public void CancelSell(int sellId);
}
