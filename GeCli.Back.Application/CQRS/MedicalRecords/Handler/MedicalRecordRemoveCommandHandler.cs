using GeCli.Back.Application.CQRS.MedicalRecords.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Handler
{
    internal class MedicalRecordRemoveCommandHandler : IRequestHandler<MedicalRecordRemoveCommand, MedicalRecord>
    {
        private IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordRemoveCommandHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<MedicalRecord> Handle(MedicalRecordRemoveCommand request, CancellationToken cancellationToken)
        {
            var record = await _medicalRecordRepository.GetMedicalRecordByIdAsync(request.Id);
            if (record == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                var result = await _medicalRecordRepository.Remove(record);
                return result;
            }
        }
    }
}
