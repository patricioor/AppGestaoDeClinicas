using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.MedicalRecords.Command
{
    public class MedicalRecordRemoveCommand : IRequest<MedicalRecord>
    {
        public int Id { get; set; }
        public MedicalRecordRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
