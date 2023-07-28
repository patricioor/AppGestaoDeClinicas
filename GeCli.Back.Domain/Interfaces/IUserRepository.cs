using GeCli.Back.Domain.Entities.User;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetUsersAsync();
        public Task<User> GetUserAsync(string login);
        public Task<User> InsertUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
    }
}
