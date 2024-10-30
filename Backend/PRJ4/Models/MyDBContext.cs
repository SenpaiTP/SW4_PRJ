using Microsoft.EntityFrameworkCore;
using PRJ4.Models;

namespace MealApp.DB
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
    }
}
