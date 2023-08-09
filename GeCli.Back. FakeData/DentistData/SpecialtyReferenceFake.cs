using Bogus;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back._FakeData.DentistData
{
    public class SpecialtyReferenceFake : Faker<SpecialtyReference>
    {
        public SpecialtyReferenceFake()
        {
            var id = new Faker().Random.Number(1, 9999);
            RuleFor(p => p.Id, _ => id);
        }
    }
}
