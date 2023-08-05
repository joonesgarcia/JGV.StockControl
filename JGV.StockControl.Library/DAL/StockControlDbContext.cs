using JGV.StockControl.Library.DAL.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JGV.StockControl.Library.DAL
{
    public class StockControlDbContext : DbContext
    {
        public StockControlDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("OnConfiguring was called!");

            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "StockControlLocalDb.db");

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = $"{dbPath}" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sell>()
                .HasOne(c => c.Client)
                .WithMany(o => o.Orders);

            modelBuilder.Entity<SoldProduct>()
                .HasOne(sell => sell.Sell)
                .WithMany(orders => orders.SoldProducts);

            modelBuilder.Entity<Product>()
                .Property(e => e.Cost)
                .HasColumnType("REAL");
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasColumnType("REAL");
            modelBuilder.Entity<SoldProduct>()
                .Property(e => e.SoldPrice)
                .HasColumnType("REAL");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }


    }
}
