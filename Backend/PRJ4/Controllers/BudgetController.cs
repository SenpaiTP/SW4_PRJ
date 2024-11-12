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

        // GET
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var budget = await _budgetRepository.GetAllAsync();

            if (budget == null)
            {
                return NotFound($"No budget made");
            }
            return Ok(budget);
        }
    }
