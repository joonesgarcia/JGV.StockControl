﻿using JGV.StockControl.Library.DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> GetAll();
    }
}
