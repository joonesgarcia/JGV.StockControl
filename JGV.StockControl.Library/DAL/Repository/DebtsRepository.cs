using JGV.StockControl.Library.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository
{
    public class DebtsRepository : IDebtsRepository
    {
        private readonly StockControlLocalDbContext _dbContext;
        private readonly IClientRepository _clientRepository;

        public DebtsRepository(StockControlLocalDbContext dbContext, IClientRepository clientRepository)
        {
            _dbContext = dbContext;
            _clientRepository = clientRepository;
        }
        public decimal GetTotalPaidByClient(int clientId)
        {
            var client = _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new Exception("Invalid ClientId");

            return _dbContext.Debts.SingleOrDefault(d => d.ClientId == clientId)!
                .TotalPaid;
        }
    }
}
