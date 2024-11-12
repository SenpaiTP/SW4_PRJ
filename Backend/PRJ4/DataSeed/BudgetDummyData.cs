using PRJ4.Models;
using Microsoft.EntityFrameworkCore;

namespace PRJ4.DataSeed
{
    public static class BudgetDummyData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>().HasData(
                new Budget { BudgetId = 1, Test = 10 },
                new Budget { BudgetId = 2, Test = 20 },
                new Budget { BudgetId = 3, Test = 30 }

            );
            
        }
    }
}