using Microsoft.AspNetCore.DataProtection.Repositories;
using PRJ4.Models;
using PRJ4.Data;
using Microsoft.EntityFrameworkCore;

namespace PRJ4.Repositories;

public class BudgetRepository: TemplateRepo<Budget>, IBudget
{
    private readonly ApplicationDbContext _context;
    public BudgetRepository(ApplicationDbContext context) : base(context) 
    {
        _context = context;
    }

    public async Task<IEnumerable<Budget>> GetAllAsync()
    {
        var budgets = await _context.Budgets 
            .ToListAsync();
        return budgets;
    }

}