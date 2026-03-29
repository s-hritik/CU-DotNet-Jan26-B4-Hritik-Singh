using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day61.Models;

public class Car
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Brand")]
    public string Brand { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Model")]
    public string Model { get; set; } = string.Empty;

    [Required]
    [Range(1900, 2100)]
    public int Year { get; set; }

    [Required]
    [Range(0.01, 10000000)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
