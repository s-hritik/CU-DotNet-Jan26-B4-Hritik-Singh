namespace Week10Assessment.Models;

public class Transaction
{
    public int Id {get;set;}
    public required string? Description {get;set;}
    public required double Amount {get;set;}
    public required string Category {get;set;}
    public required DateTime Date {get;set;}
}
