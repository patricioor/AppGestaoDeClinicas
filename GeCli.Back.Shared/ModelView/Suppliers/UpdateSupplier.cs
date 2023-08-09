using GeCli.Back.Shared.ModelView.Consumable;

namespace GeCli.Back.Shared.ModelView.Suppliers;

public class UpdateSupplier : NewSupplier
{
    public int Id { get; set; }
    public ICollection<ConsumableReference>? Consumables { get; set; }
}
