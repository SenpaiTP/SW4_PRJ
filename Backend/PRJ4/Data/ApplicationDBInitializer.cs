using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PRJ4.Models;
using System.Collections.Generic;

namespace PRJ4.Data
{
    public static class DBInitializer
    {
        public static void Seed(ApplicationDbContext context)
         {    
            SeedFIndtægt(context);

            context.SaveChanges();
            
        }

        public static void SeedFIndtægt(ApplicationDbContext context)
        {
            var findtægt = new[]
            {
                new Findtægt { Findtægt1 = 1,BrugerId = 1, Tekst ="Løn", Indtægt = 1000, Dato = DateTime.Now },
            };

            context.Findtægts.AddRange(findtægt);
            context.SaveChanges();

        }
    }
}