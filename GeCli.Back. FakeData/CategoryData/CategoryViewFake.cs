using Bogus;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back._FakeData.CategoryData;

public class CategoryViewFake : Faker<CategoryView>
{
    public CategoryViewFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ = id);
        RuleFor(p => p.Name, f => f.Lorem.Word());
    }
}
