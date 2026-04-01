using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace weeek10.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    [Required]
    public string? Category { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    public int AccountId { get; set; }

    public Account? Account { get; set; }
}
