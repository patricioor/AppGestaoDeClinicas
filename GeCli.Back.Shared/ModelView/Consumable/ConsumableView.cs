using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Shared.ModelView.Consumable;

public class ConsumableView
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public CategoryView Category { get; set; }
    public ICollection<SupplierView> Suppliers { get; set; }
}
