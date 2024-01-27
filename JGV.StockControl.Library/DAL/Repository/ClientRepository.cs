using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly StockControlLocalDbContext _dbContext;

        public ClientRepository(StockControlLocalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Client> GetAll()
        {
            return _dbContext.Clients.OrderBy(x => x.Name).ToList();
        }
        public Client? GetClientById(int? id)
        {
            if (id == null)
                return null;
            Client? client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            return client;
        }
        public void AddClient(ClientInputModel model)
        {
            Client client = new Client()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
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
                client.Name = model.Name;
                client.PhoneNumber = model.PhoneNumber;    

            _dbContext.Clients.Update(client);
            _dbContext.SaveChanges();
            }
        }
        public Client? GetClientByName(string clientName)
        {
            Client? client = _dbContext.Clients.FirstOrDefault(c => c.Name == clientName);
            return client;
        }
    }
}
