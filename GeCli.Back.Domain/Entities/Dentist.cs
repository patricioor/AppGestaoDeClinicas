namespace GeCli.Back.Domain.Entities
{
    public sealed class Dentist : Entity
    {
        public string Cro { get; set; }
        public int EmploymentId { get; set; }
        public Employment Employment { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
    }
}
