using JGV.StockControl.Library.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IProductRepository ProductRepository { get; }
        ISellRepository SellRepository { get; }
    }
}
