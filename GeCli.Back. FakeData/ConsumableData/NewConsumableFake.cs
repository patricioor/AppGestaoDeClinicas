using Bogus;
using GeCli.FakeData.CategoryData;
using GeCli.FakeData.SupplierData;
using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.FakeData.ConsumableData;

public class NewConsumableFake : Faker<NewConsumable>
{
    public NewConsumableFake()
    {
        RuleFor(p => p.Name, f => f.Lorem.Word());
        RuleFor(p => p.Description, f => f.Lorem.Sentences(5));
        RuleFor(p => p.Price, f => f.Random.Decimal(0.01m, 9999.00m));
        RuleFor(p => p.Stock, f => f.Random.Number(1, 100));
        RuleFor(p => p.Category, f => new CategoryReferenceFake().Generate());
        RuleFor(p => p.Suppliers, f => new SupplierReferenceFake().Generate(2));
    }
}
