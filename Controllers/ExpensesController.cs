using EcoScope.Data;
using EcoScope.Dtos.ExpenseDTOs;
using EcoScope.Models;
using EcoScope.Result;
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


        //Gets all expenses connected to the user
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<ExpenseDto>>> GetAllExpensesAsync()
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

        //Gets specific expense from the user
        [HttpGet]
        [Route("{expenseid:int}")]
        public async Task<ActionResult<ExpenseDto>> GetExpenseByIdAsync(int expenseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);


            var result = await expenseService.GetByIdAsync(expenseId, userIdInt);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ResultResponse>> CreateExpenseAsync(ExpenseDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);

            var result = await expenseService.CreateExpense(dto, userIdInt);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

        [HttpPut]
        [Route("{expenseId:int}/update")]
        public async Task<ActionResult<ResultResponse>> UpdateExpenseAsync(UpdateExpenseDto dto, int expenseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var userIdInt = int.Parse(userId);

            var result = await expenseService.UpdateAsync(dto, expenseId, userIdInt);

            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpDelete]
        [Route("{expenseId:int}/remove")]
        public async Task<ActionResult<ResultResponse>> RemoveExpense(int expenseId) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }


            var userIdInt = int.Parse(userId);

            var result = await expenseService.RemoveExpense(expenseId, userIdInt);

            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
