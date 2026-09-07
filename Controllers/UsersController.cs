using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
using EcoScope.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcoScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
    }
}
