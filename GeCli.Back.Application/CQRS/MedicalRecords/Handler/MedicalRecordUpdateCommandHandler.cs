using GeCli.Back.Application.CQRS.MedicalRecords.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Handler
{
    public class MedicalRecordUpdateCommandHandler : IRequestHandler<MedicalRecordUpdateCommand, MedicalRecord>
    {
        private IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordUpdateCommandHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecord> Handle(MedicalRecordUpdateCommand request, CancellationToken cancellationToken)
        {
            var record = await _medicalRecordRepository.GetMedicalRecordById(request.Id);
            if (record == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                record.Update(request.Name, request.Complaint, request.Medicate, request.Allergy, request.Disease, request.Surgery, 
                    request.Bleed, request.Heal, request.MedRecord, request.ProcedureId, request.DentistId, request.CustomerId);

                return await _medicalRecordRepository.Update(record);

            }
        }
    }
}
