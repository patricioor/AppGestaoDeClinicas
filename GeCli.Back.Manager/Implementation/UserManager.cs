using AutoMapper;
using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Manager.Interfaces.Services;
using GeCli.Back.Shared.ModelView.User;
using Microsoft.AspNetCore.Identity;

namespace GeCli.Back.Manager.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJWTService _jwt;

        public UserManager(IUserRepository userRepository, IMapper mapper, IJWTService jwt)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwt = jwt;
        }
        public async Task<UserView> GetUserAsync(string login)
        {
            return _mapper.Map<UserView>(await _userRepository.GetUserAsync(login));
        }

        public async Task<IEnumerable<UserView>> GetUsersAsync()
        {
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(await _userRepository.GetUsersAsync());
        }

        public async Task<UserView> InsertUserAsync(NewUser newUser)
        {
            var user = _mapper.Map<User>(newUser);
            PasswordToHash(user);
            return _mapper.Map<UserView>(await _userRepository.InsertUserAsync(user));
        }

        public async Task<UserView> UpdateUserAsync(User user)
        {          
            PasswordToHash(user);
            return _mapper.Map<UserView>(await _userRepository.UpdateUserAsync(user));
        }

        public async Task<LoggedUser> ValidateUserGenerateTokenAsync(User user)
        {
            var userFounded = await _userRepository.GetUserAsync(user.Login);
            if (userFounded != null)
                return null;

            if( await ValidateAndUpdateHashAsync(user, userFounded.Password))
            {
                var loggedUser = _mapper.Map<LoggedUser>(userFounded);
                loggedUser.Token = _jwt.TokenGenerate(userFounded);
                return loggedUser;
            }
            return null;
        }

        private static void PasswordToHash(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);
        }

        private async Task<bool> ValidateAndUpdateHashAsync(User User, string hash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, hash, user.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateUserAsync(user);
                    return true;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
