using GeCli.Back.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace GeCli.Back.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }

        public async Task<bool> Authenticate(string user, string password)
        {
            var result = await _singInManager.PasswordSignInAsync(user, password, false, false);
            return result.Succeeded;
        }
        public async Task<bool> RegisterUser(string user, string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = user,
                Email = email
            };

            var result = await _userManager.CreateAsync(applicationUser, password);

            if (result.Succeeded)
                await _singInManager.SignInAsync(applicationUser, false);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _singInManager.SignOutAsync();
        }
    }
}
