using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Employees
{
    public class DentistCellphone : Cellphone
    {
        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }
    }
}
