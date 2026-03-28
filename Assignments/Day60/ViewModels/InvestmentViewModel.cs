using System;
using System.ComponentModel.DataAnnotations;

namespace Day60.ViewModels;

public class InvestmentViewModel
{
    [Required(ErrorMessage = "Ticker is required")]
    [StringLength(10)]
    [Display(Name = "Ticker Symbol")]
    public string TickerSymbol { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Asset Name")]
    public string AssetName { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 10,00,000")]
    [Display(Name = "Purchase Price (₹)")]
    public decimal Price { get; set; }

    [Required]
    [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10,000")]
    public int Quantity { get; set; }

    [Display(Name = "Total Investment Value")]
    public string TotalValue => (Price * Quantity).ToString("C");
}
