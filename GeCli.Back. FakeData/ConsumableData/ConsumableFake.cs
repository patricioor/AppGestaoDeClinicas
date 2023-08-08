using Bogus;
using GeCli.Back._FakeData.CategoryData;
using GeCli.Back._FakeData.SupplierData;
using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.Back._FakeData.ConsumableData;

public class ConsumableFake : Faker<Consumable>
{
    public ConsumableFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
        RuleFor(p => p.Name, f => f.Lorem.Word());
        RuleFor(p => p.Description, f => f.Lorem.Sentences(5));
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 10000));
        RuleFor(p => p.Stock, f => f.Finance.Amount(1, 100));
        RuleFor(p => p.Category, f => new CategoryFake());
        RuleFor(p => p.Suppliers, f => new SupplierFake().Generate(1));
    }
}
