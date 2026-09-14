using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;
using EcoScope.Repositories.ExpenseRepositories;
using EcoScope.Result;
using EcoScope.Services.CategoryServices;

namespace EcoScope.Services.ExpenseServices
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository expenseRepository;

        private readonly ICategoryService categoryService;

        public ExpenseService(IExpenseRepository _expenseRepository, ICategoryService _categoryService)
        {
            expenseRepository = _expenseRepository;
            categoryService = _categoryService;
        }

        public async Task<List<ExpenseDto>> GetAllAsync(int userIdInt)
        {

            var expenses = await expenseRepository.GetAllAsync(userIdInt);

            return expenses.Select(expense => new ExpenseDto
            {
                Title = expense.Title,
                CostAmount = expense.CostAmount,
                BillingFrequency = expense.BillingFrequency,
                CategoryId = expense.CategoryId
                
            }).ToList();

        }


        public async Task<DataResult<ExpenseDto>> GetByIdAsync(int expenseId, int userIdInt)
        {
            var expense = await expenseRepository.GetByIdAsync(expenseId, userIdInt);

            

            if(expense == null)
            {
                return new DataResult<ExpenseDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Expense could not be found"
                };
            }

            var expenseDto = new ExpenseDto
            {
                Title = expense.Title,
                CostAmount = expense.CostAmount,
                BillingFrequency = expense.BillingFrequency,
                CategoryId = expense.CategoryId,
            };

            return new DataResult<ExpenseDto>
            {
                IsSuccess = true,
                Data = expenseDto,
                Message = null
            };
        }


        public async Task<ResultResponse> CreateExpense(ExpenseDto dto, int userId)
        {

            var categoryResult = await categoryService.GetCategoryByIdAsync(dto.CategoryId);

            if (!categoryResult.IsSuccess)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "Category does not exist"
                };
            }

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

            return new ResultResponse
            {
                IsSuccess = true,
                Message = "Expense created successfully"
            };
        }

        public async Task<ResultResponse> UpdateAsync(UpdateExpenseDto dto, int expenseId, int userIdInt)
        {
            var expense = await expenseRepository.GetByIdAsync(expenseId, userIdInt);


            if (expense == null)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "Expense could not be found"
                };
                //throw new ExpenseNotFoundException("Expense could not be found");
            }

            var categoryResult = await categoryService.GetCategoryByIdAsync(dto.CategoryId);

            if (!categoryResult.IsSuccess)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "Category does not exist"
                };
            }


            expense.Title = dto.Title;
            expense.CostAmount = dto.CostAmount;
            expense.BillingFrequency = dto.BillingFrequency;
            expense.CategoryId = dto.CategoryId;

            await expenseRepository.SaveAsync();

            return new ResultResponse
            {
                IsSuccess = true,
                Message = "Expense updated successfully"
            };
        }

        public async Task<ResultResponse> RemoveExpense(int expenseId, int userIdInt)
        {
            var expense = await expenseRepository.GetByIdAsync(expenseId, userIdInt);

            if(expense == null)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "Expense could not be found"
                };
            }


            expenseRepository.RemoveExpense(expense);
            await expenseRepository.SaveAsync();

            return new ResultResponse
            {
                IsSuccess = true,
                Message = "Expense removed successfully"
            };
        }


    }
}
