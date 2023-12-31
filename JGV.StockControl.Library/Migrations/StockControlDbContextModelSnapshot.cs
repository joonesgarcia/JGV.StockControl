﻿// <auto-generated />
using JGV.StockControl.Library.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JGV.StockControl.Library.Migrations
{
    [DbContext(typeof(StockControlLocalDbContext))]
    partial class StockControlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BoughtQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DiscountPromotion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFromInitialInvestment")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Sell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("InitialDebtAmount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPaidAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.SoldProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SellId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("SoldPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductId", "SellId", "SoldPrice");

                    b.HasIndex("SellId");

                    b.ToTable("SoldProducts");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Sell", b =>
                {
                    b.HasOne("JGV.StockControl.Library.DAL.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.SoldProduct", b =>
                {
                    b.HasOne("JGV.StockControl.Library.DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JGV.StockControl.Library.DAL.Models.Sell", "Sell")
                        .WithMany("SoldProducts")
                        .HasForeignKey("SellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sell");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JGV.StockControl.Library.DAL.Models.Sell", b =>
                {
                    b.Navigation("SoldProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
