using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Query
{
    public class GetDentistsQuery : IRequest<IEnumerable<Dentist>>
    {
    }
}
