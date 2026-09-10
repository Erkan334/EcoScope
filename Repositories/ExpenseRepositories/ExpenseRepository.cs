using EcoScope.Data;
using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoScope.Repositories.ExpenseRepositories
{
    public class ExpenseRepository : IExpenseRepository
    {

        private readonly EcoScopeDbContext context;

        public ExpenseRepository(EcoScopeDbContext _context)
        {
            context = _context;
        }



        public async Task<Expense> CreateExpense(Expense expense)
        {
            await context.Expenses.AddAsync(expense);

            return expense;
        }

        public void RemoveExpense(Expense expense)
        {
            context.Expenses.Remove(expense);
        }

        public async Task<List<Expense>> GetAllAsync(int userIdInt)
        {
            return await context.Expenses.Where(e => e.UserId == userIdInt).ToListAsync();

           
        }

        public async Task<Expense?> GetByIdAsync(int expenseId)
        {
            var expense = await context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId);

            return expense;
        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
