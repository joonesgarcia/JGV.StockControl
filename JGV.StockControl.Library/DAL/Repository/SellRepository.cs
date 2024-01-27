using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JGV.StockControl.Library.DAL.Repository;
public class SellRepository : ISellRepository
{
    private readonly StockControlLocalDbContext _dbContext;

    public SellRepository(StockControlLocalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void DeduceDebtValue(int sellId, decimal value)
    {
        var sell = GetSellById(sellId);
        if (sell != null) {
            sell.TotalPaidAmount += value;
            _dbContext.SaveChanges();
        }
    }

    public int GetNextSellId()
    => GetAll().OrderBy(x => x.Id)
        .Last().Id + 1;

    public Sell GetSellById(int id)
    => _dbContext.Sells
        .Include(sp => sp.SoldProducts).ThenInclude(p => p.Product)
        .SingleOrDefault(s => s.Id.Equals(id));

    public void AddSell(Sell sell)
    {
        _dbContext.Sells.Add(sell);
        _dbContext.SaveChanges();       
    }

    public void RemoveSoldProductFromSell(int sellId, SoldProduct product)
    {
        var sell = GetSellById(sellId);

        if (sell != null)
        {
            sell.SoldProducts.Remove(product);

            if (SellHasNoSoldProducts(sell))
                _dbContext.Sells.Remove(sell);

            _dbContext.SaveChanges();
        }

    }

    private bool SellHasNoSoldProducts(Sell sell)
        => !sell.SoldProducts.Any();

    public void CancelSell(int sellId)
    {
        Sell sell = _dbContext.Sells.Single(s => s.Id == sellId);
        Client client = _dbContext.Clients.Single(c => c.Orders.Contains(sell));
        
        client.Orders.Remove(sell);
        _dbContext.Sells.Remove(sell);

        _dbContext.SoldProducts.RemoveRange(
            _dbContext.SoldProducts.Where(sp => sp.Sell == sell).ToArray());

        _dbContext.SaveChanges();
    }

    public List<SellViewModel> GetAll(Client? clientFilter = null)
    {
        List<SellViewModel> result = new();
        foreach (Sell sell in _dbContext.Sells
            .Include(sp => sp.SoldProducts).ThenInclude(p => p.Product)
            .Include(c => c.Client))
        {

            SellViewModel model = new(
                sell.Id,
                DateOnly.FromDateTime(sell.Date),
                sell.Client,
                sell.SoldProducts
                    .Select(p => p.SoldPrice * p.Quantity)
                    .Sum(),
                sell.TotalPaidAmount,              
                sell.SoldProducts
                    .Select(p => (p.SoldPrice - p.Product.Cost) * p.Quantity)
                    .Sum(),
                sell.SoldProducts
                    .Select(sp => new SoldProductViewModel(
                        sell.Date.ToShortDateString(),
                        sp.ProductId,
                        sp.Product.Description,
                        sp.Quantity, 
                        sp.SoldPrice))
            );
            result.Add(model);
        }
        if (clientFilter != null)
            return result
                .OrderByDescending(x => x.Id)
                .Where(x => x.Client == clientFilter)
                .ToList();
        return result
            .OrderByDescending(x => x.Id)
            .ToList();
    }

    public List<ClientDebtViewModel> GetClientsDebtView()
    {
        List <ClientDebtViewModel> clientDebts= new();

        //int i = 1;

        //foreach (Client client in _dbContext.Clients.Include(o => o.Orders))
        //{
        //    var debt = new Debt()
        //    {
        //        Id = i,
        //        Client = client,
        //        ClientId = client.Id,
        //        Comment = string.Empty,
        //        TotalPaid = client.Orders.Sum(x => x.TotalPaidAmount),
        //        WillBePaidIn = client.Orders.OrderByDescending(x => x.Date).Last().Date.AddMonths(1)
        //    };
        //    _dbContext.Debts.Add(debt);
        //    _dbContext.SaveChanges();
        //    i++;
        //}

        foreach (Debt debt in _dbContext.Debts
            .Include(c => c.Client)
                .ThenInclude(o => o.Orders)
                    .ThenInclude(sp => sp.SoldProducts)
                        .ThenInclude(p => p.Product))
        {
            clientDebts.Add(new ClientDebtViewModel(
                debt.Id,
                debt.Client.Name,
                debt.Client.Orders.Sum(x => x.InitialDebtAmount),
                debt.Client.Orders.Sum(x => x.InitialDebtAmount) - debt.TotalPaid,
                debt.Comment,
                debt.WillBePaidIn,
                GetAll(debt.Client)));
        }

        return clientDebts.OrderByDescending(x => Tools.ExtractNumericValue(x.RemainingDebtValue)).ToList() ;    
       
    }
}

