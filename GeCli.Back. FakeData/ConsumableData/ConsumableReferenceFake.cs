using Bogus;
using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.FakeData.ConsumableData
{
    public class ConsumableReferenceFake : Faker<ConsumableReference>
    {
        public ConsumableReferenceFake()
        {
            var id = new Faker().Random.Number(1, 9999);
            RuleFor(p => p.Id, _ => id);
            RuleFor(p => p.Name, f => f.Lorem.Word());
        }
    }
}
