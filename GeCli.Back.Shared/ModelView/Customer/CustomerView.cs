using GeCli.Back.Shared.ModelView.CommunClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class CustomerView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerAddressView Address { get; set; }
        public IEnumerable<CustomerCellphoneView> Cellphones { get; set; }
        public DateTime BirthDay { get; set; }
        public NewGender Gender { get; set; }
        public string CPF { get; set; }
    }
}
