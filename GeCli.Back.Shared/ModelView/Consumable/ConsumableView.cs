using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Shared.ModelView.Consumable;

public class ConsumableView : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public CategoryView Category { get; set; }
    public ICollection<SupplierReference> Suppliers { get; set; }

    public object Clone()
    {
        var consumable = (ConsumableView)MemberwiseClone();
        var suppliers = new List<SupplierReference>();
        consumable.Suppliers.ToList().ForEach(p => suppliers.Add((SupplierReference)p.Clone()));
        consumable.Suppliers = suppliers;
        return consumable;
    }

    public ConsumableView ClonedTyped()
    {
        return (ConsumableView)MemberwiseClone();
    }
}
