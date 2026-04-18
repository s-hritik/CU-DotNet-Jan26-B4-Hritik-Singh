using System;
using System.Collections.Generic;
using ApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiService.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasIndex(e => e.CategoryName, "CategoryName");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(15);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Picture).HasColumnType("image");
        });


        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);
            entity.HasIndex(e => e.CategoryId, "CategoryID");
            entity.HasIndex(e => e.ProductName, "ProductName");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.ProductName).HasMaxLength(40).IsRequired();
            entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

            entity.Property(e => e.UnitPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10,2)");

            entity.HasOne(p => p.Category)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CategoryId)
                  .HasConstraintName("FK_Products_Categories");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
