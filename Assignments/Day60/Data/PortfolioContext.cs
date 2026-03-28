
using Microsoft.EntityFrameworkCore;
using Day60.Models;

namespace Day60.Data;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

public DbSet<Day60.Models.Investment> Investment { get; set; } = default!;
}
