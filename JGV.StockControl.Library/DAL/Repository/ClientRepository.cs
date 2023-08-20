﻿using JGV.StockControl.Library.BLL.InputModel;
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
            Client cliente = _dbContext.Clients.Single(x => x.Id == id);
            _dbContext.Clients.Remove(cliente);
            _dbContext.SaveChanges();
        }

        public void UpdateClientById(int id, ClientInputModel model)
        {
            Client cliente = _dbContext.Clients.Single(x => x.Id == id);

            cliente.Name = model.name;
            cliente.PhoneNumber = model.phoneNumber;    

            _dbContext.Clients.Update(cliente);
            _dbContext.SaveChanges();
        }
    }
}
