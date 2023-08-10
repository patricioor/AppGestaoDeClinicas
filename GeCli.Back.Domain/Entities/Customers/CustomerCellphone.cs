using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Customers
{
    public sealed class CustomerCellphone : Cellphone
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}