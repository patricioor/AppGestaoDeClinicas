using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.User;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var loggedUser = await _userManager.ValidateUserGenerateTokenAsync(user);
            if (loggedUser != null)
            {
                return Ok(loggedUser);
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Post (NewUser user)
        {
            var insertUser = await _userManager.InsertUserAsync(user);
            return CreatedAtAction(nameof(Get), new { login = user.Login }, insertUser);
        }
    }
}
