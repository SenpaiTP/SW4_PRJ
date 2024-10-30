using PRJ4.Repositories;
using PRJ4.Models;
using Microsoft.AspNetCore.Mvc;


namespace PRJ4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
    {
        private readonly BudgetRepository _budgetRepository;

        public BudgetController(BudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        // GET: api/Budget/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var budget = await _budgetRepository.GetBudgetbyBudgetId(id);
            if (budget == null)
            {
                return NotFound($"No budget found with BudgetId {id}");
            }
            return Ok(budget);
        }
    }
