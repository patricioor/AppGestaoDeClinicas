using GeCli.Back.Domain.Entities.User;

namespace GeCli.Back.Manager.Interfaces.Services
{
    public interface IJWTService
    {
        string TokenGenerate(User user);
    }
}
