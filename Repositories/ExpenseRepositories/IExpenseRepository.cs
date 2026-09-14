using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;

namespace EcoScope.Repositories.ExpenseRepositories
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllAsync(int userIdInt);

        Task<Expense?> GetByIdAsync(int expenseId, int userIdInt);

        Task CreateExpense(Expense expense);


        void RemoveExpense(Expense expense);

        Task SaveAsync();

    }
}
