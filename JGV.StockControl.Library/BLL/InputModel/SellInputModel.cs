using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.BLL.InputModel;
public record SellInputModel(int clientId, DateTime sellDate, List<Product> soldProducts);

