using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Customers
{
    public class CustomerAddress : Address
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
