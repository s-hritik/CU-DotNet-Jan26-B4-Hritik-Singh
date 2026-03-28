using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day60.Models;

public class Investment
{
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string TickerSymbol { get; set; } = string.Empty;

    [Required]
    public string AssetName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PurchasePrice { get; set; }

    [Required]
    [Range(1, 10000)]
    public int Quantity { get; set; }

    [DataType(DataType.Date)]
    public DateTime PurchaseDate { get; set; }
}
