using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository;
public interface IClientRepository
{
    public void AddClient(ClientInputModel model);
    public void UpdateClientById(int id, ClientInputModel model);
    public void DeleteClientById(int id);
}

