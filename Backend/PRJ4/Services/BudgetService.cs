
using PRJ4.Models;
using PRJ4.Repositories;


namespace PRJ4.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepo _budgetRepository;

      
        public BudgetService(BudgetRepo budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }


        //Calculate the monthly savings for an Budget
        public decimal CalculateMonthlySavings(decimal MonthlySavingsAmount, int SavingsPeriodInMonths)
        {
            if (SavingsPeriodInMonths <= 0)
            {
                throw new ArgumentException("Months should be more than 0");
            }

            decimal monthlyAmount = MonthlySavingsAmount / SavingsPeriodInMonths;
            return monthlyAmount;
        }
        
 

    }
}