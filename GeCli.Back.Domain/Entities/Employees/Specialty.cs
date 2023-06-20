using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Employees
{
    public class Specialty : Entity
    {
        public string Description { get; set; }
        public ICollection<Dentist> Dentists { get; set; }
    }
}