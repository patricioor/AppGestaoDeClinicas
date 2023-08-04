using Bogus;
using GeCli.Back.Domain.Entities.Customers;
using System.Text.Json.Serialization;

namespace GeCli.Back._FakeData.CellphoneData
{
    public class CustomerCellphonesFake : Faker<CustomerCellphone>
    {
        public CustomerCellphonesFake(int id)
        {
            RuleFor(x => x.CustomerId, _ => id);
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
