using Microsoft.EntityFrameworkCore;
using TravelApi.Models;

namespace TravelApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Destination>()
                    .Property(t => t.CityName)
                    .IsRequired();
        modelBuilder.Entity<Destination>()
                    .Property(t => t.Country)
                    .IsRequired();
        modelBuilder.Entity<Destination>()
                    .Property(t => t.Description)
                    .HasMaxLength(200);
        modelBuilder.Entity<Destination>()
                    .Property(t => t.Rating)
                    .HasDefaultValue(3);
    }

    public DbSet<Destination> Destinations { get; set; } = null!;
}
