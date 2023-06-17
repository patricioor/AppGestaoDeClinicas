namespace GeCli.Back.Domain.Entities
{
    public sealed class Customer : Entity
    {
        public string Name { get; set; }
        public string Cellphone { get;  set; }
        public DateTime BirthDay { get;  set; }
        public char Gender { get;  set; }
        public string CPF { get;  set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdate { get; set; }

        public Address Address { get; set; }

        //public int? ResponsibleId { get; set; }
        //public Responsible Responsible { get; set; }
        //public IEnumerable<MedicalRecord> MedicalRecords { get; set; }
    }
}
