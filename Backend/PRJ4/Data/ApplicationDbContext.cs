using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PRJ4.Models;

namespace PRJ4.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bruger> Brugers { get; set; }

    public virtual DbSet<Findtægt> Findtægts { get; set; }

    public virtual DbSet<Fudgifter> Fudgifters { get; set; }

    public virtual DbSet<Vindtægter> Vindtægters { get; set; }

    public virtual DbSet<Vudgifter> Vudgifters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Projekt4;User ID=SA;Password=Vedex2016***;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bruger>(entity =>
        {
            entity.HasKey(e => e.BrugerId).HasName("PK__Bruger__6FA2FB30AE403A15");

            entity.ToTable("Bruger");

            entity.Property(e => e.BrugerId).HasColumnName("BrugerID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Navn).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Findtægt>(entity =>
        {
            entity.HasKey(e => e.Findtægt1).HasName("PK__Findtægt__2E1D3E026C53B483");

            entity.ToTable("Findtægt");

            entity.Property(e => e.Findtægt1).HasColumnName("Findtægt");
            entity.Property(e => e.BrugerId).HasColumnName("BrugerID");
            entity.Property(e => e.Dato).HasColumnType("datetime");
            entity.Property(e => e.Indtægt).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tekst).HasMaxLength(255);

            entity.HasOne(d => d.Bruger).WithMany(p => p.Findtægts)
                .HasForeignKey(d => d.BrugerId)
                .HasConstraintName("FK__Findtægt__Bruger__4222D4EF");
        });

        modelBuilder.Entity<Fudgifter>(entity =>
        {
            entity.HasKey(e => e.FudgiftId).HasName("PK__Fudgifte__12BF03E8C7E5D9C7");

            entity.ToTable("Fudgifter");

            entity.Property(e => e.FudgiftId).HasColumnName("FudgiftID");
            entity.Property(e => e.BrugerId).HasColumnName("BrugerID");
            entity.Property(e => e.Dato).HasColumnType("datetime");
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tekst).HasMaxLength(255);

            entity.HasOne(d => d.Bruger).WithMany(p => p.Fudgifters)
                .HasForeignKey(d => d.BrugerId)
                .HasConstraintName("FK__Fudgifter__Bruge__3C69FB99");
        });

        modelBuilder.Entity<Vindtægter>(entity =>
        {
            entity.HasKey(e => e.VindtægtId).HasName("PK__Vindtægt__83BCC36FD3543C24");

            entity.ToTable("Vindtægter");

            entity.Property(e => e.VindtægtId).HasColumnName("VindtægtID");
            entity.Property(e => e.BrugerId).HasColumnName("BrugerID");
            entity.Property(e => e.Dato).HasColumnType("datetime");
            entity.Property(e => e.Indtægt).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tekst).HasMaxLength(255);

            entity.HasOne(d => d.Bruger).WithMany(p => p.Vindtægters)
                .HasForeignKey(d => d.BrugerId)
                .HasConstraintName("FK__Vindtægte__Bruge__3F466844");
        });

        modelBuilder.Entity<Vudgifter>(entity =>
        {
            entity.HasKey(e => e.VudgiftId).HasName("PK__Vudgifte__7E8DE19A4E24036F");

            entity.ToTable("Vudgifter");

            entity.Property(e => e.VudgiftId).HasColumnName("VudgiftID");
            entity.Property(e => e.BrugerId).HasColumnName("BrugerID");
            entity.Property(e => e.Dato).HasColumnType("datetime");
            entity.Property(e => e.KategoriId)
                .HasMaxLength(255)
                .HasColumnName("KategoriID");
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tekst).HasMaxLength(255);

            entity.HasOne(d => d.Bruger).WithMany(p => p.Vudgifters)
                .HasForeignKey(d => d.BrugerId)
                .HasConstraintName("FK__Vudgifter__Bruge__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
