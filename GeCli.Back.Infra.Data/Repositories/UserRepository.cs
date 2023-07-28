using GeCli.Back.Domain.Entities.User;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;
        public UserRepository(ApplicationDbContext userContext) 
        { 
            _userContext = userContext;
        }
        public async Task<User> GetUserAsync(string login)
        {
            return await _userContext.DbUsers
                .Include(p => p.Functions)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _userContext.DbUsers.AsNoTracking().ToListAsync();
        }

        public async Task<User> InsertUserAsync(User user)
        {
            await InserUserFunctionAsync(user);
            await _userContext.DbUsers.AddAsync(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        private async Task InserUserFunctionAsync(User user)
        {
            var functionsFounded = new List<Function>();
            foreach(var function in user.Functions)
            {
                var functionFounded = await _userContext.Functions.FindAsync(function.Id);
                functionsFounded.Add(functionFounded);
            }
            user.Functions = functionsFounded;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var userSearched = await _userContext.DbUsers.FindAsync(user.Login);
            if (userSearched != null)
                return null;

            _userContext.Entry(userSearched).CurrentValues.SetValues(user);
            await _userContext.SaveChangesAsync();
            return userSearched;
        }
    }
}
