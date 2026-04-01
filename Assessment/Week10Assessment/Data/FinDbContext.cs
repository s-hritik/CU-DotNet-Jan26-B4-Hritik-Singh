using Microsoft.EntityFrameworkCore;
using weeek10.Models;

namespace weeek10.Data;

public class FinDbContext : DbContext
{
    public FinDbContext(DbContextOptions<FinDbContext> options)
        : base(options) { }

    public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<Account> Accounts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
        .HasOne(t => t.Account)
        .WithMany(a => a.Transactions)
        .HasForeignKey(t => t.AccountId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
