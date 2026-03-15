using Microsoft.EntityFrameworkCore;
using Week10Assessment.Models;

namespace Week10Assessment.Data;

public class AccountContext : DbContext
{
    public AccountContext(DbContextOptions<AccountContext> options) : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}