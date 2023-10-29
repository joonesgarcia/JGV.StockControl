using JGV.StockControl.Library.DAL.Repository;

namespace JGV.StockControl.Library.DAL.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IProductRepository ProductRepository { get; }
        ISellRepository SellRepository { get; }
    }
}
