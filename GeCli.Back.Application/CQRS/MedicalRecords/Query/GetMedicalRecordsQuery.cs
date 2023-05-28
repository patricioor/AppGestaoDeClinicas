using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Query
{
    public class GetMedicalRecordsQuery : IRequest<IEnumerable<MedicalRecord>>
    {
    }
}
