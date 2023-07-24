using GeCli.Back.Domain.Entities.AbstractClasses;

namespace GeCli.Back.Domain.Entities.Customers
{
    public sealed class Customer : Entity
    {
        public string Name { get; set; }
        public IEnumerable<CustomerCellphone> Cellphones { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public string CPF { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public CustomerAddress Address { get; set; }

        //public int? ResponsibleId { get; set; }
        //public Responsible Responsible { get; set; }
        //public IEnumerable<MedicalRecord> MedicalRecords { get; set; }
    }
}
