using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Shared.ModelView.Consumable;

public class NewConsumable : ICloneable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public CategoryReference Category { get; set; }
    public ICollection<SupplierReference> Suppliers { get; set; }

    public object Clone()
    {
        var consumable = (NewConsumable)MemberwiseClone();
        var supplier = new List<SupplierReference>();
        consumable.Suppliers.ToList().ForEach(p => supplier.Add((SupplierReference)p.Clone()));
        consumable.Suppliers = supplier;
        return consumable;
    }

    public NewConsumable ClonedTyped()
    {
        return (NewConsumable) MemberwiseClone();
    }
}
