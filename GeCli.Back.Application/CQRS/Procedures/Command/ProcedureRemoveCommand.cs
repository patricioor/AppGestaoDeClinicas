using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Command
{
    public class ProcedureRemoveCommand : IRequest<Procedure>
    {
        public int Id { get; set; }

        public ProcedureRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
