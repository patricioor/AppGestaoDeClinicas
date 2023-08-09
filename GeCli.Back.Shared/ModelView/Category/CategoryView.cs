namespace GeCli.Back.Shared.ModelView.Category;

public class CategoryView
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CategoryView ClonedTyped()
    {
        return (CategoryView)MemberwiseClone();
    }
}
