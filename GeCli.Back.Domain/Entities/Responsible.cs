using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Customers;

namespace GeCli.Back.Domain.Entities
{
    public sealed class Responsible : Entity
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
