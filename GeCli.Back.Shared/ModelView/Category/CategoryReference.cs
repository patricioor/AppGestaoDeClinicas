namespace GeCli.Back.Shared.ModelView.Category;

public class CategoryReference
{
    public int Id { get; set; }

    public CategoryReference ClonedTyped()
    {
        return (CategoryReference)MemberwiseClone();
    }
}
