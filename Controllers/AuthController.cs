using EcoScope.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcoScope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;

        public AuthController(SignInManager<User> _signInManager)
        {
            signInManager = _signInManager;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Ok();
        }

        [HttpGet]
        [Route("me/role")]
        public ActionResult GetUserRole()
        {
            var isAdmin = User.IsInRole("Admin");

            return Ok(new
            {
                isAdmin = isAdmin
            });
        }
    }
}