using EcoScope.Data;
using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;
using EcoScope.Services.ExpenseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EcoScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService expenseService;

        public ExpensesController(IExpenseService _expenseService)
        {
            expenseService = _expenseService;

        }



        [HttpGet]
        [Route("/all")]
        public async Task<ActionResult<List<Expense>>> GetAllExpensesAsync()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (user == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(user);

            var expenses = await expenseService.GetAllAsync(userIdInt);
            return Ok(expenses);

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateExpenseAsync(ExpenseDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);

            await expenseService.CreateExpense(dto, userIdInt);

            return Ok();

        }

        [HttpPut]
        [Route("{expenseId:int}/update")]
        public async Task<IActionResult> UpdateExpenseAsync(UpdateExpenseDto dto, int expenseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);

            await expenseService.UpdateAsync(dto, expenseId, userIdInt);
            return Ok();
        }


        [HttpDelete]
        [Route("{expenseId:int}/remove")]
        public async Task<IActionResult> RemoveExpense(int expenseId) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);

            await expenseService.RemoveExpense(expenseId, userIdInt);

            return Ok();
        }
    }
}
