using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace JGV.StockControl.Library.DAL.Repository;
public class SellRepository : ISellRepository
{
    private readonly StockControlDbContext _dbContext;

    public SellRepository(StockControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Sell GetSellById(int id)
    => _dbContext.Sells
        .Include(sp => sp.SoldProducts).ThenInclude(p => p.Product)
        .SingleOrDefault(s => s.Id.Equals(id));
    
    public void AddSell(SellInputModel model)
    {
        Client client = _dbContext.Clients.First(c => c.Id == model.ClientId);

        Sell sell = new()
        {
            Date = model.SellDate,
            Client = client,
            SoldProducts = model.SoldProducts,
            TotalPaidAmount = model.DownPayment
        };

        client.Orders.Add(sell);
        _dbContext.Sells.Add(sell);

        _dbContext.SaveChanges();
    }

    public void CancelSell(int sellId)
    {
        Sell sell = _dbContext.Sells.Single(s => s.Id == sellId);
        Client client = _dbContext.Clients.Single(c => c.Orders.Contains(sell));
        
        client.Orders.Remove(sell);
        _dbContext.Sells.Remove(sell);

        _dbContext.SaveChanges();
    }

    public List<SellViewModel> GetAll()
    {
        List<SellViewModel> result = new();
        foreach (Sell sell in _dbContext.Sells
            .Include(sp => sp.SoldProducts).ThenInclude(p => p.Product)
            .Include(c => c.Client))
        {

            SellViewModel model = new(
                sell.Id,
                DateOnly.FromDateTime(sell.Date),
                sell.Client.Name,
                sell.SoldProducts
                    .Select(p => p.SoldPrice * p.Quantity)
                    .Sum(),
                sell.TotalPaidAmount,              
                sell.SoldProducts
                    .Select(p => p.SoldPrice - p.Product.Cost)
                    .Sum(),
                sell.SoldProducts
                    .Select(sp => new SoldProductViewModel(
                        sp.Product.Description,
                        sp.Quantity, 
                        sp.SoldPrice))
            );
            result.Add(model);
        }
        return result
            .OrderByDescending(x => x.Id)
            .ToList();
    }
}

