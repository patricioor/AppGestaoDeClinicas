using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Employees;

namespace GeCli.Back.Domain.Entities;

public sealed class Employment : Entity
{
    public ICollection<Dentist> Dentists { get; private set; }
}
