using GeCli.Back.Shared.ModelView.CommunClasses;

namespace GeCli.Back.Shared.ModelView.Customer
{
    public class CustomerView : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerAddressView Address { get; set; }
        public ICollection<CustomerCellphoneView> Cellphones { get; set; }
        public DateTime BirthDay { get; set; }
        public NewGender Gender { get; set; }
        public string CPF { get; set; }

        public object Clone()
        {
            var customer = (CustomerView)MemberwiseClone();
            customer.Address = (CustomerAddressView)customer.Address.Clone();
            var cellphone = new List<CustomerCellphoneView>();
            customer.Cellphones.ToList().ForEach(p => cellphone.Add((CustomerCellphoneView)p.Clone()));
            customer.Cellphones = cellphone;
            return customer;
        }

        public CustomerView CloneTyped()
        {
            return (CustomerView)MemberwiseClone();
        }
    }
}
