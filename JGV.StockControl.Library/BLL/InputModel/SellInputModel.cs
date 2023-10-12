using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.BLL.InputModel;
public record SellInputModel(int ClientId, DateTime SellDate, List<SoldProduct> SoldProducts, decimal DownPayment = 0);

