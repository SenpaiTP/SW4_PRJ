using PRJ4.Repositories;
using PRJ4.Models;
using PRJ4.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace PRJ4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetController : ControllerBase
{
        private readonly BudgetRepo _budgetRepository;

        public BudgetController(BudgetRepo budgetRepository)
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
                return BadRequest($"Budget with id {id} not found."); 
            }

            return Ok(budget); 
        }


        // POST
        [HttpPost] 
        public IActionResult AddBudget(BudgetDTO budgetDTO) //Add a budget
        {
            if (budgetDTO == null) 
            {
                return BadRequest("Budget values is not valid");
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

        // UPDATE: api/budget/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, BudgetDTO budgetDTO) //Update budget by id
        {
            if (budgetDTO == null)
            {
                return BadRequest("Invalid budget data.");
            }

            var oldBudget = await _budgetRepository.GetByIdAsync(id); 
            if (oldBudget == null)
            {
                return NotFound($"Budget with id {id} not found.");
            }

           
            oldBudget.BrugerId = budgetDTO.BrugerId ?? oldBudget.BrugerId; 
            oldBudget.SavingsGoal = budgetDTO.SavingsGoal;
            oldBudget.MonthlySavingsAmount = budgetDTO.MonthlySavingsAmount;
            oldBudget.SavingsPeriodInMonths = budgetDTO.SavingsPeriodInMonths;

           
            await _budgetRepository.Update(oldBudget); 


            return Ok(oldBudget); 
        }


        // DELETE: api/budget/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBudget(int id) //Delete bugdet by id
        {
   
            var budget = _budgetRepository.GetByIdAsync(id).Result; 
            
            if (budget == null)
            {
  
                return NotFound($"Budget with id {id} not found.");
            }

            var deletedBudget = _budgetRepository.Delete(id).Result; 
            
            if (deletedBudget == null)
            {
                return BadRequest("Budget deletion failed.");
            }

  
            return NoContent();
        }
            
}
