namespace GeCli.Back.Domain.Account
{
    public interface IAuthenticate
    {
        public Task<bool> Authenticate(string user, string password);
        public Task<bool> RegisterUser(string user, string email, string password);
        public Task Logout();
    }
}
