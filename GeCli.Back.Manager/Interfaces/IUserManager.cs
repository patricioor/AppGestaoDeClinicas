using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Shared.ModelView.User;

namespace GeCli.Back.Manager.Interfaces
{
    public interface IUserManager
    {
        public Task<ICollection<UserView>> GetUsersAsync();
        public Task<UserView> GetUserAsync(string login);
        public Task<UserView> InsertUserAsync(NewUser newUser);
        public Task<UserView> UpdateUserAsync(User user);
        public Task<LoggedUser> ValidateUserGenerateTokenAsync(User user);
    }
}
