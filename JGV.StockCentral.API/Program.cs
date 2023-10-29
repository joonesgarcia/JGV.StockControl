using JGV.StockCentral.API;
using JGV.StockControl.Library.DAL;
using JGV.StockControl.Library.DAL.IRepository;
using JGV.StockControl.Library.DAL.Models;
using JGV.StockControl.Library.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/Clientes", (IUnitOfWork db) =>
{
    return Results.Ok(db.ClientRepository.GetAll());
});
app.MapGet("/Produtos", (IUnitOfWork db) =>
{
    return Results.Ok(db.ProductRepository.GetAll());
});
app.MapGet("/Vendas", (IUnitOfWork db) =>
{
    return Results.Ok(db.SellRepository.GetAll());
});

app.Run();