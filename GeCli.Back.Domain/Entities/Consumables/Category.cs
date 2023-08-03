using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Consumables;
public sealed class Category : Entity
{
    public string Name { get; set; }

    public ICollection<Consumable> Consumables { get; private set; }
}
