using Bogus;
using GeCli.Back.Shared.ModelView.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back._FakeData.CellphoneData
{
    public class NewCellphoneFake : Faker<NewCustomerCellphone>
    {
        public NewCellphoneFake() 
        {
            RuleFor(p => p.Number, f => f.Phone.PhoneNumber("11#########"));
        }
    }
}
