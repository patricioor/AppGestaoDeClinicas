using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Employees
{
    public sealed class Employment : Entity
    {
        public ICollection<Dentist> Dentists { get; private set; }
    }
}
