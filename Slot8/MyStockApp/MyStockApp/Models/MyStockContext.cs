using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyStockApp.Models;

public partial class MyStockContext : DbContext
{
    public MyStockContext()
    {
    }

    public MyStockContext(DbContextOptions<MyStockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyStockDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
