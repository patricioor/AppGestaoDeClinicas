using Bogus;
using Bogus.DataSets;
using GeCli.Back.Shared.ModelView.Customer;

namespace GeCli.Back._FakeData.CellphoneData
{
    public class CellphoneViewFake : Faker<CustomerCellphoneView>
    {
        public CellphoneViewFake()
        {
            RuleFor(p => p.Id, f => f.Random.Number(1, 10));
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
