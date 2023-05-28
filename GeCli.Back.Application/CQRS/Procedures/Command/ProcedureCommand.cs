using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Command
{
    public class ProcedureCommand : IRequest<Procedure>
    {
        public string Name { get; set; }
        public int ConsumableId { get; set; }
    }
}
