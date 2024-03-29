﻿using JGV.StockControl.Library.BLL.InputModel;
using JGV.StockControl.Library.BLL.ViewModel;
using JGV.StockControl.Library.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository;
public interface ISellRepository
{
    public List<SellViewModel> GetAll(Client? client = null);
    public void AddSell(Sell sell);
    public void CancelSell(int sellId);
    public Sell GetSellById(int id);
    public int GetNextSellId();
    public bool DeduceDebtValue(int sellId, decimal value);
    public void RemoveSoldProductFromSell(int sellId, SoldProduct product);
}
