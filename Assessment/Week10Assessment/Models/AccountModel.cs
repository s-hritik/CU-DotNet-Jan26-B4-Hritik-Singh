namespace Week10Assessment.Models;

public class Account {
    public int Id { get; set; }
    public required string AccountName { get; set; }
    public required double Balance { get; set; }
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}


