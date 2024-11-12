using PRJ4.Repositories;
using PRJ4.Models;
using PRJ4.DTOs;
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
        public async Task<IActionResult> GetAllBudgets() //Get all budgets
        {
            var budget = await _budgetRepository.GetAllAsync();

            if (budget == null)
            {
                return NotFound($"No budget made");
            }
            return Ok(budget);
        }

        // GET: api/budget/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudget(int id)
        {
            var budget = await _budgetRepository.GetByIdAsync(id); 
            if (budget == null)
            {
                return BadRequest($"No budgets with id {id}."); 
            }

            return Ok(budget); 
        }


        // POST
        [HttpPost] 
        public IActionResult AddBudget(BudgetDTO budgetDTO) //Add a budget
        {
            if (budgetDTO == null) 
            {
                return BadRequest("Budget values cannot be null");
            }
            
            var budget = new Budget
            {
                BrugerId = budgetDTO.BrugerId,
                SavingsGoal = budgetDTO.SavingsGoal,
                MonthlySavingsAmount = budgetDTO.MonthlySavingsAmount,
                SavingsPeriodInMonths = budgetDTO.SavingsPeriodInMonths
            };

            var createdBudget = _budgetRepository.AddAsync(budget);

            return CreatedAtAction(nameof(GetBudget), new { id = createdBudget.Id }, createdBudget);

        }
            
    }
