using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Query
{
    public class GetProceduresQuery : IRequest<IEnumerable<Procedure>>
    {
    }
}
