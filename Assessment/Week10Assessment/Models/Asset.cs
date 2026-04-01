using System;

namespace weeek10.Models;

public class Asset
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Symbol { get; set; }
    public double PurchasedPrice { get; set; }
    public int Quantity { get; set; }
    public double CurrentPrice { get; set; }

    public double TotalPrice => CurrentPrice * Quantity;
    public double ProfitNLoss => (CurrentPrice - PurchasedPrice) * Quantity;

}
