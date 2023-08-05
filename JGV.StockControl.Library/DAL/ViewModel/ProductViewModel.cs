using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGV.StockControl.Library.DAL.ViewModel;

public record ProductViewModel
{
    public ProductViewModel(string description, decimal cost, decimal price, int availableQuantity, string? discountPromotion)
    {
        Description = description;
        Cost = cost.ToString("C", new CultureInfo("pt-BR"));
        Price = price.ToString("C", new CultureInfo("pt-BR"));
        AvailableQuantity = availableQuantity;
        DiscountPromotion = discountPromotion;
    }

    [System.ComponentModel.DisplayName("Descrição")]
    public string Description { get; set; }
    [System.ComponentModel.DisplayName("Preço de custo")]
    public string Cost { get; set; }
    [System.ComponentModel.DisplayName("Preço de venda")]
    public string Price { get; set; }
    [System.ComponentModel.DisplayName("Quantidade disponível")]
    public int AvailableQuantity { get; set; }
    [System.ComponentModel.DisplayName("Promoção")]
    public string? DiscountPromotion { get; set; } = null;
}
    

