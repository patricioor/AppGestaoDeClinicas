using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.Back.Domain.Entities.Suppliers;

public sealed class Supplier : Entity
{
    public string Name { get; set; }
    public string CNPJ { get; set; }
    public SupplierAddress Address { get; set; }
    public ICollection<SupplierCellphone> Cellphones { get; set; }
    public ICollection<Consumable> Consumables { get; set; }
    public string Vendor { get; set; }
}
