using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoSWD.Models;

public partial class DemoSwdContext : DbContext
{
    public DemoSwdContext()
    {
    }

    public DemoSwdContext(DbContextOptions<DemoSwdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faq> Faqs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAQs__3213E83F832EC52E");

            entity.ToTable("FAQs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
