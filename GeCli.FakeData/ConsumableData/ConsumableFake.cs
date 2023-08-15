using Bogus;
using GeCli.FakeData.CategoryData;
using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.FakeData.ConsumableData;

public class ConsumableFake : Faker<Consumable>
{
    public ConsumableFake()
    {
        var id = new Faker().Random.Number(1, 9999);
        RuleFor(p => p.Id, _ => id);
        RuleFor(p => p.Name, f => f.Lorem.Word());
        RuleFor(p => p.Description, f => f.Lorem.Sentences(1));
        RuleFor(p => p.Price, f => f.Random.Decimal(0.01m, 9999.00m));
        RuleFor(p => p.Stock, f => f.Random.Number(1, 100));
        RuleFor(p => p.Category, f => new CategoryFake());
    }
}
