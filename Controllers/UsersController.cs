using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
using EcoScope.Result;
using EcoScope.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcoScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        

        [HttpPut]
        [Route("me/name")]
        public async Task<ActionResult<ResultResponse>> UpdateUserName(UpdateUserNameDto dto) 
        {
            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out var userIdInt))
            {
                return Unauthorized();
            }

            var result = await userService.UpdateUserName(dto, userIdInt);

            if (!result.IsSuccess) 
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id) 
        {
            var result = await userService.GetUserById(id);

            if (!result.IsSuccess)
            {
                return NotFound(result);
            }


            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers() 
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
          
        }
    }
}
