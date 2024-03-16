using JGV.StockControl.Library.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.Services
{
    public class ClientsService
    {
        private readonly IUnitOfWork unitOfWork;

        public ClientsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<ClientInfo> GetAllClients()
        {
            return unitOfWork.ClientRepository.GetAllClients()
                .Select(x => new ClientInfo() { Id = x.Id, Name = x.Name });
        }
        public class ClientInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
