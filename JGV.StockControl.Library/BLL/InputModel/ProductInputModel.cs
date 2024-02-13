using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.BLL.InputModel
{
    public record ProductInputModel(string Description, int BoughtQuantity, decimal Cost, decimal Price, string? DiscountPromotion, bool IsFromInitialInvestment = false);
}
