using Bogus;
using GeCli.Back.Domain.Entities.Suppliers;

namespace GeCli.FakeData.SupplierData
{
    public class SupplierCellphoneFake : Faker<SupplierCellphone>
    {
        public SupplierCellphoneFake(int id)
        {
            RuleFor(x => x.SupplierId, _ => id);
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
