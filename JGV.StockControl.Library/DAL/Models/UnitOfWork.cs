using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Repository;


namespace JGV.StockControl.Library.DAL.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClientRepository _clientRepository;
        private IProductRepository _productRepository;
        private ISellRepository _sellRepository;

        public IClientRepository ClientRepository { get => _clientRepository; init => _clientRepository = value; }
        public IProductRepository ProductRepository { get => _productRepository; init => _productRepository = value; }
        public ISellRepository SellRepository { get => _sellRepository; init => _sellRepository = value; }

        public UnitOfWork(IClientRepository clientRepository, IProductRepository productRepository, ISellRepository sellRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _sellRepository = sellRepository;
        }
    }
}
