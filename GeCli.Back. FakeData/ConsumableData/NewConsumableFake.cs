using Bogus;
using GeCli.Back._FakeData.CategoryData;
using GeCli.Back._FakeData.SupplierData;
using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.Back._FakeData.ConsumableData;

public class NewConsumableFake : Faker<NewConsumable>
{
    public NewConsumableFake()
    {
        RuleFor(p => p.Name, f => f.Lorem.Word());
        RuleFor(p => p.Description, f => f.Lorem.Sentences(5));
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 10000));
        RuleFor(p => p.Stock, f => f.Finance.Amount(1, 100));
        RuleFor(p => p.Category, f => new CategoryReferenceFake().Generate());
        RuleFor(p => p.Suppliers, f => new SupplierReferenceFake().Generate(3));
    }
}
