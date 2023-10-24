using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly StockControlDbContext _dbContext;

        public ClientRepository(StockControlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Client> GetClients()
        {
            return _dbContext.Clients.ToList();
        }
        public string? GetClientNameById(int id)
        {
            Client? client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            return client?.Name;
        }
        public void AddClient(ClientInputModel model)
        {
            Client client = new Client()
            {
                Name = model.name,
                PhoneNumber = model.phoneNumber,
            };
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void DeleteClientById(int id)
        {
            Client? client = _dbContext.Clients.SingleOrDefault(x => x.Id == id);
            if (client != null)
            {
                _dbContext.Clients.Remove(client);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateClientById(int id, ClientInputModel model)
        {
            Client? client = _dbContext.Clients.Single(x => x.Id == id);
            if (client != null)
            {
                client.Name = model.name;
                client.PhoneNumber = model.phoneNumber;    

            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            }
        }
    }
}
