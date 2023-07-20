using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Manager.Implementation;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeCli.Back.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            var loggedUser = await _userManager.ValidateUserGenerateTokenAsync(user);
            if (loggedUser != null)
            {
                return Ok(loggedUser);
            }
            return Unauthorized();
        }

        [Authorize(Roles = "President, Leader")]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            string login = User.Identity.Name;
            var user = await _userManager.GetUserAsync(login);
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult> Post(NewUser user)
        {
            var insertUser = await _userManager.InsertUserAsync(user);
            return CreatedAtAction(nameof(Get), new { login = user.Login }, insertUser);
        }
    }
}
