using Microsoft.EntityFrameworkCore;
using PRJ4.Models;
//using PRJ4.DataSeed;

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

    //public DbSet<Budget> Budget { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bruger>().ToTable("Bruger");
        //modelBuilder.Entity<Budget>().ToTable("Budget");
        modelBuilder.Entity<Findtægt>().ToTable("Findtægt");
        modelBuilder.Entity<Fudgifter>().ToTable("Fudgifter");
        modelBuilder.Entity<Kategori>().ToTable("Kategori");
        modelBuilder.Entity<Vindtægter>().ToTable("Vintægter");
        modelBuilder.Entity<Vudgifter>().ToTable("Vudgifter");
        modelBuilder.Entity<Kategori>().ToTable("Kategrier");

        base.OnModelCreating(modelBuilder);

        
    }
}