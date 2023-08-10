using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Suppliers;

public sealed class SupplierCellphone : Cellphone
{
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}
