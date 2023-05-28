using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Command
{
    public class MedicalRecordCommand : IRequest<MedicalRecord>
    {
        public string Name { get; set; }
        public string MedRecord { get;  set; }
        public string Complaint { get;  set; }
        public string? Medicate { get;  set; }
        public string? Allergy { get;  set; }
        public string? Disease { get; set; }
        public string? Surgery { get; set; }
        public bool Bleed { get; set; }
        public bool Heal { get; set; }
        public int ProcedureId { get; set; }
        public int DentistId { get; set; }
        public int CustomerId { get; set; }

    }
}
