using Bogus;
using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.Back._FakeData.CategoryData;

public class CategoryFake : Faker<Category>
{
    public CategoryFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ = id);
        RuleFor(p => p.Name, f => f.Lorem.Word());
    }
}
