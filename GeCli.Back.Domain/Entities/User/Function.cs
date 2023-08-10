namespace GeCli.Back.Domain.Entities.User;

public sealed class Function
{
    public int Id { get; set; }
    public string Description { get; set; }

    public ICollection<User> Users { get; set; }
}
