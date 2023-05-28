using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Query
{
    public class GetMedicalRecordByIdQuery : IRequest<MedicalRecord>
    {
        public int Id { get; set; }
        public GetMedicalRecordByIdQuery(int id)
        {
            Id = id;
        }
    }
}
