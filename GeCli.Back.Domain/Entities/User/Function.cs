namespace GeCli.Back.Domain.Entities.User
{
    public class Function
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
