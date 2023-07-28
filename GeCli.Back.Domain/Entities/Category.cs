using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Consumables;

namespace GeCli.Back.Domain.Entities;
public sealed class Category : Entity
{
    public string Name { get; set; }

    public ICollection<Consumable> Consumables { get; private set; }
}
