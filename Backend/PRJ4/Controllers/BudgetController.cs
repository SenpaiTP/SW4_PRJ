using PRJ4.Repositories;
using PRJ4.Models;
using Microsoft.AspNetCore.Mvc;
using PRJ4.DTOs;
using PRJ4.Data;


namespace PRJ4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        // GET: api/Budget/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var budget = await _budgetRepository.GetByIdAsync(id);
            if (budget == null)
            {
                return NotFound($"No budgets found with BudgetId {id}");
            }
            return Ok(budget);
        }

        //GET: api/budget

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var budgets = await _budgetRepository.GetAllAsync();
            if (budgets == null || !budgets.Any())
            {
                return NotFound("No budgets found");
            }
            return Ok(budgets);
        }


        //Post
        [HttpPost]
        public async Task<ActionResult<Budget>> Add(BudgetDTO budgetDTO)
        {
            if(budgetDTO==null)
            {
                return BadRequest("Budget cannot be null");
            }
            

            var newBudget = new Budget
            {
                BrugerId = budgetDTO.BrugerId,
                Test = budgetDTO.Test
            };
            await _budgetRepository.AddAsync(newBudget);
            await _budgetRepository.SaveChangesAsync();
            return Ok(newBudget);
        }
    }
