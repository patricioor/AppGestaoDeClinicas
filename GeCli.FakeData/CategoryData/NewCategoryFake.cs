using Bogus;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.FakeData.CategoryData;

public class NewCategoryFake : Faker<NewCategory>
{
    public NewCategoryFake()
    {
        RuleFor(p => p.Name, f => f.Lorem.Word());

    }
}
