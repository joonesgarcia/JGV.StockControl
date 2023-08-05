using JGV.StockControl.Library.DAL.InputModel;
using JGV.StockControl.Library.DAL.Models;

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
        Client cliente = _dbContext.Clients.First(c => c.Id == model.clientId);

        Sell sell = new Sell()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            Client = cliente,
            SoldProducts = model.soldProducts
        };

        foreach (SoldProduct s in model.soldProducts)
        {
            Product product = _dbContext.Products.Find(s.Product);
            product.AvailableQuantity -= s.Quantity;

            _dbContext.SoldProducts.Add(s);
        }

        cliente.Orders.Add(sell);
        _dbContext.Sells.Add(sell);

        _dbContext.SaveChanges();
    }

    public void CancelSell(int sellId)
    {
        Sell sell = _dbContext.Sells.Single(s => s.Id == sellId);
        Client client = _dbContext.Clients.First(c => c.Orders.Contains(sell));

        foreach (SoldProduct s in sell.SoldProducts)
        {
            Product product = _dbContext.Products.Find(s.Product);
            product.AvailableQuantity += s.Quantity;

            _dbContext.SoldProducts.Remove(s);
        }

        client.Orders.Remove(sell);
        _dbContext.Sells.Remove(sell);

        _dbContext.SaveChanges();
    }
}

