using Bogus;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back._FakeData.CategoryData;

public class UpdateCategoryFake : Faker<UpdateCategory>
{
    public UpdateCategoryFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, f => id);
        RuleFor(p => p.Name, p => p.Lorem.Word());
    }
}
