using Bogus;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back._FakeData.CategoryData;

public class CategoryReferenceFake : Faker<CategoryReference>
{
    public CategoryReferenceFake()
    {
        var id = new Faker().Random.Number(1, 9999);
    }
}
