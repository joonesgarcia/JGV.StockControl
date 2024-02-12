using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly ISellRepository _sellRepository;
        private readonly IClientRepository _clientRepository;

        public DebtsRepository(StockControlLocalDbContext dbContext, ISellRepository sellRepository)
        {
            _dbContext = dbContext;
            _sellRepository = sellRepository;
        }
        public decimal GetTotalPaidByClient(int clientId)
        {
            var client = _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new Exception("Invalid ClientId");

            return _dbContext.Debts.SingleOrDefault(d => d.ClientId == clientId)!
                .TotalPaid;
        }
        public void BuildClientsDebts(int clientId = -1)
        {
            int i = 1;

            foreach (Client client in _dbContext.Clients.Include(o => o.Orders))
            {
                var debt = new Debt()
                {
                    Id = i,
                    Client = client,
                    ClientId = client.Id,
                    Comment = string.Empty,
                    TotalPaid = client.Orders.Sum(x => x.TotalPaidAmount),
                    WillBePaidIn = client.Orders.OrderByDescending(x => x.Date).Last().Date.AddMonths(1)
                };
                _dbContext.Debts.Add(debt);
                _dbContext.SaveChanges();
                i++;
            }
        }

        public void EditClientDebt(int clientId, string? comment = null, DateTime? willBePaidIn = null)
        {
            Debt debt = _dbContext.Debts.Single(x => x.ClientId == clientId);

            if (comment != null)
                debt.Comment = comment;
            if (willBePaidIn != null)
                debt.WillBePaidIn = (DateTime)willBePaidIn;

            _dbContext.SaveChanges();
        }

        public List<ClientDebtViewModel> GetClientsDebtView(int clientId = -1)
        {
            List<ClientDebtViewModel> clientDebts = new();

            foreach (Debt debt in _dbContext.Debts
                .Include(c => c.Client)
                    .ThenInclude(o => o.Orders)
                        .ThenInclude(sp => sp.SoldProducts)
                            .ThenInclude(p => p.Product))
            {
                clientDebts.Add(new ClientDebtViewModel(
                    debt.Id,
                    debt.Client.Name,
                    debt.ClientId,
                    debt.Client.Orders.Sum(x => x.InitialDebtAmount),
                    debt.Client.Orders.Sum(x => x.InitialDebtAmount) - debt.TotalPaid,
                    debt.Comment,
                    debt.WillBePaidIn,
                    _sellRepository.GetAll(debt.Client)));
            }

            if (clientId != -1)
                return clientDebts
                    .OrderByDescending(x => Tools.ExtractNumericValue(x.RemainingDebtValue))
                    .Where(c => clientId == c.ClientId)
                    .ToList();

            return clientDebts.OrderByDescending(x => Tools.ExtractNumericValue(x.RemainingDebtValue)).ToList();

        }
    }
}
