using Bogus;
using GeCli.Back.Domain.Entities.Customers;

namespace GeCli.Back._FakeData.CellphoneData
{
    public class CellphonesFake : Faker<CustomerCellphone>
    {
        public CellphonesFake(int id)
        {
            RuleFor(x => x.CustomerId, _ => id);
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
