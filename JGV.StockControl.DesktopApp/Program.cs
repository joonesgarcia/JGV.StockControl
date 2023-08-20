using JGV.StockControl.Library.DAL;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JGV.StockControl.DesktopApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "StockControlLocalDb.db");
            services.AddDbContext<StockControlDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ISellRepository, SellRepository>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            ServiceProvider = services.BuildServiceProvider();
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
            Application.Run(new MainForm(ServiceProvider.GetRequiredService<IUnitOfWork>()));
        }
    }
}