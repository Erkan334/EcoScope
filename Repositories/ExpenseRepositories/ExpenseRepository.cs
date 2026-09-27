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



        public async Task CreateExpense(Expense expense)
        {
            await context.Expenses.AddAsync(expense);

        }

        public void RemoveExpense(Expense expense)
        {
            context.Expenses.Remove(expense);
        }

        public async Task<List<Expense>> GetAllAsync(int userIdInt)
        {
            return await context.Expenses.AsNoTracking()
                                         .Where(e => e.UserId == userIdInt).Include(e => e.Category)
                                         .ToListAsync();

           
        }

        //Doesnt use AsNoTracking because UpdateExpense-method use this method.
        public async Task<Expense?> GetByIdAsync(int expenseId, int userIdInt)
        {
            return await context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId && e.UserId == userIdInt);

        }


        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
