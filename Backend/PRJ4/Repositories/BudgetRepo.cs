using Microsoft.AspNetCore.DataProtection.Repositories;
using PRJ4.Models;
using PRJ4.Data;
using Microsoft.EntityFrameworkCore;

namespace PRJ4.Repositories;

public class BudgetRepo: TemplateRepo<Budget>, IBudgetRepo
{
    private readonly ApplicationDbContext _context;
    public BudgetRepo(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }

    

   
   
}

