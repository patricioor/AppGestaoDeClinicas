namespace GeCli.Back.Domain.Entities
{
    public sealed class MedicalRecord : Entity
    {
        public string MedRecord { get; protected set; }
        public string Complaint { get; protected set; }
        public string? Medicate { get; protected set; }
        public string? Allergy { get; protected set; }
        public string? Disease { get; protected set; }
        public string? Surgery { get; protected set; }
        public bool Bleed { get; protected set; }
        public bool Heal { get; protected set; }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
