using GeCli.Back.Domain.Validation;

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


        public MedicalRecord(string name, string complaint, string? medicate, string? allergy, string? disease, string? surgery, bool bleed, bool heal, string medRecord)
        {
            ValidateDomainName(name);
            ValidateDomainMedRecord(complaint, medicate, allergy, disease, surgery, bleed, heal,medRecord);
        }

        public MedicalRecord(int id, string name, string complaint, string? medicate, string? allergy, string? disease, string? surgery, bool bleed, bool heal, string medRecord)
        {
            ValidateDomainId(id);
            ValidateDomainName(name);
            ValidateDomainMedRecord(complaint, medicate, allergy, disease, surgery, bleed, heal, medRecord);
        }

        public void Update(string name, string complaint, string? medicate, string? allergy, string? disease, string? surgery, bool bleed, bool heal, string medRecord, int procedureId, int dentistId, int customerId)
        {
            ValidateDomainName(name);
            ValidateDomainMedRecord(complaint, medicate, allergy, disease, surgery, bleed, heal, medRecord);

            ProcedureId = procedureId;
            DentistId = dentistId;
            CustomerId = customerId;
        }

        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

        public int DentistId { get; set; }
        public Dentist Dentist { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        private void ValidateDomainMedRecord(string complaint, string? medicate, string? allergy, string? disease, string? surgery, bool bleed, bool heal, string medRecord )
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(complaint), "Invalid complaint. Complaint is required");
            DomainExceptionValidation.When(complaint.Length > 1000, "Too long. The complaint can only have a maximum of 1000 characters");

            DomainExceptionValidation.When(medicate.Length > 100, "Too long. The medicate can only have a maximum of 100 characters.");
            DomainExceptionValidation.When(allergy.Length > 100, "Too long. The complaint can only have a maximum of 100 characters.");
            DomainExceptionValidation.When(disease.Length > 100, "Too long. The complaint can only have a maximum of 100 characters.");
            DomainExceptionValidation.When(surgery.Length > 100, "Too long. The complaint can only have a maximum of 100 characters.");

            DomainExceptionValidation.When(String.IsNullOrEmpty(medRecord), "Invalid Medical Record.Medical record is required");
            DomainExceptionValidation.When(medRecord.Length > 5000, "The medical record can only have a maximum of 5000 characters.");


            Complaint = complaint;
            Medicate = medicate; 
            Allergy = allergy;
            Disease = disease;
            Surgery = surgery;
            Bleed = bleed;
            Heal = heal;
            MedRecord = medRecord;
        }
    }
}
