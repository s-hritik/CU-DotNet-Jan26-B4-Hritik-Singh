using System;
using System.ComponentModel.DataAnnotations;

namespace weeek10.Models;

public class Account
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Account Name")]
    public string? AccountNumber { get; set; }
    [Required]
    [Display(Name = "Account Type")]
    public string? AccountType { get; set; }
    [Display(Name = "Balance (Rs)")]
    public decimal Balance { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Opened on")]
    public DateTime OpenedOn { get; set; }

    public List<Transaction> Transactions { get; set; } = new();
}
