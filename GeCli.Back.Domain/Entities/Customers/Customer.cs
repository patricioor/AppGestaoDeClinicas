using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Customers
{
    public sealed class Customer : Entity
    {
        public string Name { get; set; }
        public ICollection<CustomerCellphone> CustomerCellphones { get; set; }
        public DateTime BirthDay { get; set; }
        public char Gender { get; set; }
        public string CPF { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public CustomerAddress CustomerAddress { get; set; }

        //public int? ResponsibleId { get; set; }
        //public Responsible Responsible { get; set; }
        //public IEnumerable<MedicalRecord> MedicalRecords { get; set; }
    }
}
