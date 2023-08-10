namespace GeCli.Back.Domain.Entities.User;

public sealed class User
{
    public string Login { get; set; }
    public string Password { get; set; }

    public ICollection<Function> Functions { get; set; }

    public User()
    {
        Functions = new HashSet<Function>();
    }
}
