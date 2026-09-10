using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
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
        public async Task<IActionResult> UpdateUserName(UpdateUserNameDto dto) 
        {
            var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(userId, out var userIdInt))
            {
                return Unauthorized();
            }

            await userService.UpdateUserName(dto, userIdInt);

            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<ActionResult<List<User>>> GetUserById(int id) 
        {
            var user = await userService.GetUserById(id);

            if (user == null)
            {
                return NotFound("User could not be found");
            }

            return Ok(user);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<User>>> GetAllUsers() 
        {
            var users = await userService.GetAllUsers();
            return Ok(users);
          
        }
    }
}
