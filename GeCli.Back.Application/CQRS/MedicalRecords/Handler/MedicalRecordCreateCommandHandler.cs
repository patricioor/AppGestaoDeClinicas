using GeCli.Back.Application.CQRS.MedicalRecords.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Handler
{
    public class MedicalRecordCreateCommandHandler : IRequestHandler<MedicalRecordCreateCommand, MedicalRecord>
    {
        private IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordCreateCommandHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecord> Handle(MedicalRecordCreateCommand request, CancellationToken cancellationToken)
        {
            var record = new MedicalRecord(request.Name, request.Complaint, request.Medicate, request.Allergy, request.Disease, request.Surgery, request.Bleed, request.Heal, request.MedRecord);

            if(record == null)
            {
                throw new ArgumentNullException("Error creating entity.");
            }
            else
            {
                record.ProcedureId = request.ProcedureId;
                record.DentistId = request.DentistId;
                record.CustomerId = request.CustomerId;
             
                return await _medicalRecordRepository.Create(record);
            }
        }
    }
}
