using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PRJ4.Data;
using PRJ4.Models;

namespace PRJ4.Repositories
{
    public class FindtægtRepo : TemplateRepo<Findtægt>,IFIndtægtRepo
    {
        public FindtægtRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}