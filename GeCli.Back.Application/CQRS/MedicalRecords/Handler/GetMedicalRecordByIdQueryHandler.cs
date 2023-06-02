using GeCli.Back.Application.CQRS.MedicalRecords.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Handler
{
    public class GetMedicalRecordByIdQueryHandler : IRequestHandler<GetMedicalRecordByIdQuery, MedicalRecord>
    {
        private IMedicalRecordRepository _medicalRecordRepository;
        public GetMedicalRecordByIdQueryHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }
        public async Task<MedicalRecord> Handle(GetMedicalRecordByIdQuery request, CancellationToken cancellationToken)
        {
            return await _medicalRecordRepository.GetMedicalRecordByIdAsync(request.Id);
        }
    }
}
