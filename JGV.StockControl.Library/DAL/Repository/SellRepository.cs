using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using System.Security;

namespace JGV.StockControl.Library.DAL.Repository;
public class SellRepository : ISellRepository
{
    private readonly StockControlDbContext _dbContext;

    public SellRepository(StockControlDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddSell(SellInputModel model)
    {
        Client client = _dbContext.Clients.First(c => c.Id == model.clientId);

        Sell sell = new()
        {
            Date = model.sellDate,
            Client = client,
            SoldProducts = model.soldProducts
        };

        client.Orders.Add(sell);
        _dbContext.Sells.Add(sell);

        _dbContext.SaveChanges();
    }

    public void CancelSell(int sellId)
    {
        Sell sell = _dbContext.Sells.Single(s => s.Id == sellId);
        Client client = _dbContext.Clients.First(c => c.Orders.Contains(sell));
        
        client.Orders.Remove(sell);
        _dbContext.Sells.Remove(sell);

        _dbContext.SaveChanges();
    }

    public List<SellViewModel> GetSells()
    {
        List<SellViewModel> result = new();
        //foreach (Sell sell in _dbContext.Sells)
        //{
        //    SellViewModel model = new()
        //    {
        //        Id = sell.Id,
        //        Date = sell.Date,
        //        ClientName = sell.Client.Name,
        //        TotalPaidAmount = sell.TotalPaidAmount,
        //        InitialDebtValue = _dbContext.SoldProducts
        //                                .Where(sp => sp.Sell == sell)
        //                                .Select(p => p.SoldPrice)
        //                                .Sum(),
        //        Profit = (from sp in _dbContext.SoldProducts
        //                  join p in _dbContext.Products on sp.ProductId equals p.Id
        //                  select ( sp.SoldPrice - p.Cost ) * sp.Quantity
        //                  ).Sum()
        //    };
        //    result.Add(model);
        //}
        return result;
    }
}

