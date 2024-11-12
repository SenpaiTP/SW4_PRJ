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

    public async Task<IEnumerable<Budget>> GetAllAsync()
    {
        var budgets = await _context.Budgets 
            .ToListAsync();
        return budgets;
    }

    public async Task<Budget> AddAsync(Budget budget)
    {
        await _context.Budgets.AddAsync(budget);
        return budget;
    }

    public async Task<Budget> GetByIdAsync(int budgetId)
    {
        return await _context.Set<Budget>()
            .FirstOrDefaultAsync(budget => budget.BudgetId == budgetId);
    }

}