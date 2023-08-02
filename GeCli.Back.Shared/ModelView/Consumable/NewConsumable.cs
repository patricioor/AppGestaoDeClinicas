using GeCli.Back.Shared.ModelView.Category;
using GeCli.Back.Shared.ModelView.Suppliers;

namespace GeCli.Back.Shared.ModelView.Consumable;

public class NewConsumable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public CategoryReference Category { get; set; }
    public ICollection<SupplierReference> Suppliers { get; set; }
}
