namespace GeCli.Back.Shared.ModelView.User
{
    public class LoggedUser
    {
        public string Login { get; set; }

        public IEnumerable<FunctionView> Functions { get; set; }

        public string Token { get; set; }
    }
}
