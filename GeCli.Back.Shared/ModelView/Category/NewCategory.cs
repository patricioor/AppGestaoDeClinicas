namespace GeCli.Back.Shared.ModelView.Category
{
    public class NewCategory
    {
        public string Name { get; set; }

        public NewCategory ClonedTyped()
        {
            return (NewCategory)MemberwiseClone();
        }
    }
}