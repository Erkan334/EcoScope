using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Exceptions.ExpenseExceptions;
using EcoScope.Models;
using EcoScope.Repositories.ExpenseRepositories;

namespace EcoScope.Services.ExpenseServices
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseService(IExpenseRepository _expenseRepository)
        {
            expenseRepository = _expenseRepository;
        }
        public async Task CreateExpense(ExpenseDto dto, int userId)
        {
            var expense = new Expense
            {
                Title = dto.Title,
                CostAmount = dto.CostAmount,
                BillingFrequency = dto.BillingFrequency,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            await expenseRepository.CreateExpense(expense);
            await expenseRepository.SaveAsync();
        }

       

        public async Task RemoveExpense(int expenseId, int userIdInt)
        {
            var expense = await expenseRepository.GetByIdAsync(expenseId);

            if(expense == null)
            {
                throw new ExpenseNotFoundException("Expense could not be found");
            }

            if(expense.UserId != userIdInt) 
            {
                throw new ExpenseUnauthorizedException();
            }

            expenseRepository.RemoveExpense(expense);
            await expenseRepository.SaveAsync();
        }

        public async Task<List<Expense>> GetAllAsync(int userIdInt)
        {
        
            return await expenseRepository.GetAllAsync(userIdInt);
 
        }

        public Task<Expense?> GetByIdAsync(int expenseId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UpdateExpenseDto dto, int expenseId, int userIdInt)
        {
            var expense = await expenseRepository.GetByIdAsync(expenseId);


            if(expense == null)
            {
                throw new ExpenseNotFoundException("Expense could not be found");
            }


            if(expense.UserId != userIdInt)
            {
                throw new ExpenseUnauthorizedException();
            }

            expense.Title = dto.Title;
            expense.CostAmount = dto.CostAmount;
            expense.BillingFrequency = dto.BillingFrequency;
            expense.CategoryId = dto.CategoryId;

            await expenseRepository.SaveAsync();
        }
    }
}
