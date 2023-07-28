namespace GeCli.Back.Shared.ModelView.User
{
    public class NewUser
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<ReferenceFunction> Functions { get; set; }
    }
}
