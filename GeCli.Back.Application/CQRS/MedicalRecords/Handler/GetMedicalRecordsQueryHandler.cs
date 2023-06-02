using GeCli.Back.Application.CQRS.MedicalRecords.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Handler
{
    public class GetMedicalRecordsQueryHandler : IRequestHandler<GetMedicalRecordsQuery, IEnumerable<MedicalRecord>>
    {
        private IMedicalRecordRepository _medicalRecordRepository;

        public GetMedicalRecordsQueryHandler(IMedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public async Task<IEnumerable<MedicalRecord>> Handle(GetMedicalRecordsQuery request, CancellationToken cancellationToken)
        {
            return await _medicalRecordRepository.GetMedicalRecordsAsync();
        }
    }
}
