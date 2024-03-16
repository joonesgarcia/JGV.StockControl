using JGV.StockControl.DesktopApp.Forms;
using JGV.StockControl.DesktopApp.Forms.Products;
using JGV.StockControl.Library.DAL;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using JGV.StockControl.Library.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JGV.StockControl.DesktopApp
{
    internal static class Program
    {
        private static IServiceProvider _serviceProvider = null!;
        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "StockControlLocalDb.db");
            services.AddDbContext<StockControlLocalDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));
            
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ISellRepository, SellRepository>();
            services.AddSingleton<IDebtsRepository, DebtsRepository>();

            services.AddSingleton<DebtDetailsForm>();
            services.AddSingleton<AddProductForm>();
            services.AddSingleton<AddSellForm>();
            services.AddSingleton<SellDetailsForm>();

            services.AddSingleton<ClientsService>();
            services.AddSingleton<ProductsService>();
            services.AddSingleton<SellsService>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            _serviceProvider = services.BuildServiceProvider();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ConfigureServices();
            Application.Run(new MainForm(_serviceProvider));
        }
    }
}