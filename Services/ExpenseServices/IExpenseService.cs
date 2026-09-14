using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;
using EcoScope.Result;

namespace EcoScope.Services.ExpenseServices
{
    public interface IExpenseService
    {
        Task<List<ExpenseDto>> GetAllAsync(int userIdInt);

        Task<DataResult<ExpenseDto>> GetByIdAsync(int expenseId, int userIdInt);

        Task<ResultResponse> CreateExpense(ExpenseDto dto, int userId);


        Task<ResultResponse> UpdateAsync(UpdateExpenseDto dto, int expenseId, int userId);

        Task<ResultResponse> RemoveExpense(int expenseId, int userIdInt);

    }
}
