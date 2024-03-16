using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.Services;
using Microsoft.EntityFrameworkCore;

namespace JGV.StockControl.Library.DAL.Repository
{
    public class DebtsRepository : IDebtsRepository
    {
        private readonly StockControlLocalDbContext _dbContext;
        private readonly IClientRepository _clientRepository;

        public DebtsRepository(StockControlLocalDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public decimal GetTotalPaidByClient(int clientId)
        {
            var client = _clientRepository.GetClientById(clientId);
            if (client == null)
                throw new Exception("Invalid ClientId");

            return _dbContext.Debts.SingleOrDefault(d => d.ClientId == clientId)!
                .TotalPaid;
        }
        /// <summary>
        /// Used only when doing build/payload
        /// </summary>
        //public void BuildClientsDebts()
        //{
        //    int i = 1;

        //    foreach (Client client in _dbContext.Clients.Include(o => o.Orders))
        //    {
        //        var debt = new Debt()
        //        {
        //            Id = i,
        //            Client = client,
        //            ClientId = client.Id,
        //            Comment = string.Empty,
        //            TotalPaid = client.Orders.Sum(x => x.TotalPaidAmount),
        //            WillBePaidIn = client.Orders.OrderByDescending(x => x.Date).Last().Date.AddMonths(1)
        //        };
        //        _dbContext.Debts.Add(debt);
        //        _dbContext.SaveChanges();
        //        i++;
        //    }
        //}

        public void EditClientDebt(int clientId, string? comment = null, DateTime? willBePaidIn = null)
        {
            Debt debt = _dbContext.Debts.Single(x => x.ClientId == clientId);

            if (comment != null)
                debt.Comment = comment;
            if (willBePaidIn != null)
                debt.WillBePaidIn = (DateTime)willBePaidIn;

            _dbContext.SaveChanges();
        }

        public List<ClientDebtOutputModel> GetClientsDebtView(int clientId = -1)
        {
            List<ClientDebtOutputModel> clientDebts = new();

            foreach (Debt debt in _dbContext.Debts
                .Include(c => c.Client)
                    .ThenInclude(o => o.Orders)
                        .ThenInclude(sp => sp.SoldProducts)
                            .ThenInclude(p => p.Product))
            {
                clientDebts.Add(new ClientDebtOutputModel(
                    debt.Id,
                    debt.Client.Name,
                    debt.ClientId,
                    debt.Client.Orders.Sum(x => x.InitialDebtAmount),
                    debt.Client.Orders.Sum(x => x.InitialDebtAmount) - debt.TotalPaid,
                    debt.Comment,
                    debt.WillBePaidIn));
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
