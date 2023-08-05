using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.DAL.InputModel;
public record SellInputModel(int clientId, List<SoldProduct> soldProducts);

