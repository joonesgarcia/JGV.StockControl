using JGV.StockControl.Library.BLL.InputModel;

namespace JGV.StockControl.Library.DAL.Repository;
public interface IClientRepository
{
    public void AddClient(ClientInputModel model);
    public void UpdateClientById(int id, ClientInputModel model);
    public void DeleteClientById(int id);
}

