using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;

namespace JGV.StockControl.Library.Services
{
    public class SellsService
    {
        private readonly IUnitOfWork unitOfWork;

        public SellsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<SellOutputModel> GetAllSellsView(int? clientId = null)
        {
            List<SellOutputModel> result = new();

            foreach (Sell sell in unitOfWork.SellRepository.GetAllSells())
            {
                SellOutputModel model = GetSellView(sell);
                result.Add(model);
            }

            // filter
            if (clientId != null)
                return result
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.Client.Id == clientId)
                    .ToList();

            return result
                .OrderByDescending(x => x.Id)
                .ToList();
        }
        public SellOutputModel GetSellView(Sell sell)
        {
            return new SellOutputModel(
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
                        .Select(sp => new SoldProductOutputModel(
                            sell.Date.ToShortDateString(),
                            sp.ProductId,
                            sp.Product.Description,
                            sp.Quantity,
                            sp.SoldPrice)));
        }
    }
}
