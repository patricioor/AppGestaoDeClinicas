using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Suppliers
{
    public class SupplierAddress : Address
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
