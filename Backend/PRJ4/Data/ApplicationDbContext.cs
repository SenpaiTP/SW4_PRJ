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

    public DbSet<Bruger> Brugers { get; set; }
    public DbSet<Kategori> Kategorier {get; set;}
    public DbSet<Findtægt> Findtægts { get; set; }
    public DbSet<Fudgifter> Fudgifters { get; set; }
    public DbSet<Vindtægter> Vindtægters { get; set; }
    public DbSet<Vudgifter> Vudgifters { get; set; }
    public DbSet<Budget> Budgets { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bruger>().ToTable("Bruger");
        modelBuilder.Entity<Budget>().ToTable("Budget");
        modelBuilder.Entity<Findtægt>().ToTable("Findtægt");
        modelBuilder.Entity<Fudgifter>().ToTable("Fudgifter");
        modelBuilder.Entity<Kategori>().ToTable("Kategori");
        modelBuilder.Entity<Vindtægter>().ToTable("Vintægter");
        modelBuilder.Entity<Vudgifter>().ToTable("Vudgifter");
        modelBuilder.Entity<Kategori>().ToTable("Kategorier");


        // Dummydata for Bruger
    modelBuilder.Entity<Bruger>().HasData(
        new Bruger
        {
            BrugerId = 1,
            Navn = "Test Bruger 1",
            Email = "test1@example.com",
            Password = "password123"
        },
        new Bruger
        {
            BrugerId = 2,
            Navn = "Test Bruger 2",
            Email = "test2@example.com",
            Password = "password456"
        },
        new Bruger
        {
            BrugerId = 3,
            Navn = "Test Bruger 3",
            Email = "test3@example.com",
            Password = "password789"
        }
    );
    
        base.OnModelCreating(modelBuilder);
    }
}