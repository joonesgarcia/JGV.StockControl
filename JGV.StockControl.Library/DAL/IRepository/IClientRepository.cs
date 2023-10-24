using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.Repository;
public interface IClientRepository
{
    public void AddClient(ClientInputModel model);
    public void UpdateClientById(int id, ClientInputModel model);
    public void DeleteClientById(int id);
    public string? GetClientNameById(int id);
    public List<Client> GetClients();
}

