using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using JGV.StockControl.Library.DAL;
using Microsoft.EntityFrameworkCore;

namespace JGV.StockCentral.API
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(this WebApplicationBuilder webApplicationBuilder)
        {
            var services = webApplicationBuilder.Services;

            string dbPath = Path.Combine(Directory.GetCurrentDirectory() + "\\bin\\Debug\\net6.0\\", "StockControlLocalDb.db");
            services.AddDbContext<StockControlLocalDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISellRepository, SellRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.BuildServiceProvider();
        }
    }
}
