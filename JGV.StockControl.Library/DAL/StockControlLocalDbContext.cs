using JGV.StockControl.Library.DAL.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace JGV.StockControl.Library.DAL
{
    public class StockControlLocalDbContext : DbContext
    {
        public StockControlLocalDbContext()
        {

        }
        public StockControlLocalDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "StockControlLocalDb.db");

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = $"{dbPath}" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure a custom value converter for the Date property
            var dateConverter = new ValueConverter<DateTime, string>(
                v => v.ToString("dd/MM/yyyy"),   // Convert DateTime to string
                v => DateTime.ParseExact(v, "dd/MM/yyyy", CultureInfo.InvariantCulture) // Parse string to DateTime
            );

            modelBuilder.Entity<SoldProduct>()
                .HasKey(k => new { k.ProductId, k.SellId });

            modelBuilder.Entity<Client>()
                .HasMany(o => o.Orders)
                .WithOne(c => c.Client);

            modelBuilder.Entity<Sell>()
                .HasMany(sp => sp.SoldProducts)
                .WithOne(s => s.Sell);

            modelBuilder.Entity<SoldProduct>()
                .HasOne(p => p.Product);
            modelBuilder.Entity<SoldProduct>()
                .HasOne(s => s.Sell);


            modelBuilder.Entity<Product>()
                .Property(e => e.Cost)             
                .HasColumnType("REAL");
            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasColumnType("REAL");

            modelBuilder.Entity<SoldProduct>()
                .Property(e => e.SoldPrice)
                .HasColumnType("REAL");

            modelBuilder.Entity<Sell>()
                .Property(s => s.Date)
                .HasConversion(dateConverter);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SoldProduct> SoldProducts { get; set; }
        public DbSet<Sell> Sells { get; set; }

    }

}
