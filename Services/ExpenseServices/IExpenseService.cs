using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;

namespace EcoScope.Services.ExpenseServices
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAllAsync(int userIdInt);

        Task<Expense?> GetByIdAsync(int expenseId);

        Task CreateExpense(ExpenseDto dto, int userId);


        Task UpdateAsync(UpdateExpenseDto dto, int expenseId, int userId);

        Task RemoveExpense(int expenseId, int userIdInt);

    }
}
