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

    public IEnumerable<Sell> GetAllSells(int? clientId = null)
    {
        var sells = _dbContext.Sells
            .Include(c => c.Client)
            .Include(sp => sp.SoldProducts)
                .ThenInclude(p => p.Product)
            .ToList();

        if (clientId != null)
            return sells
                .OrderByDescending(x => x.Id)
                .Where(x => x.ClientId == clientId)
                .ToList();

        return sells
            .OrderByDescending(x => x.Id)
            .ToList();
    }
    public Sell? GetSellById(int id)
    => _dbContext.Sells
        .Include(c => c.Client)
        .Include(sp => sp.SoldProducts)
            .ThenInclude(p => p.Product)
        .SingleOrDefault(s => s.Id.Equals(id));
    public void AddSell(Sell sell)
    {
        _dbContext.Sells.Add(sell);
        _dbContext.SaveChanges();       
    }
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


    public bool DeduceDebtFromSell(int sellId, decimal value)
    {
        Sell? sell = _dbContext.Sells.SingleOrDefault(s => s.Id.Equals(sellId));
        if (sell == null) return false;

        Debt? debt = _dbContext.Debts.SingleOrDefault(d => d.ClientId == sell.ClientId);
        if (debt == null) return false;

        sell.TotalPaidAmount += value;
        debt.TotalPaid += value;

        _dbContext.SaveChanges();
        return true;
    }
    public void RemoveSoldProductFromSell(int sellId, SoldProduct product)
    {
        Sell? sell = _dbContext.Sells.SingleOrDefault(s => s.Id.Equals(sellId));
        if (sell == null) return;

        sell.SoldProducts.Remove(product);

        if (!sell.SoldProducts.Any())
            _dbContext.Sells.Remove(sell);

        _dbContext.SaveChanges();
    }
}

