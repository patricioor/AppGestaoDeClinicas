using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Query
{
    public class GetDentistByIdQuery : IRequest<Dentist>
    {
        public int Id { get; set; }
        public GetDentistByIdQuery(int id)
        {
            Id = id;
        }
    }
}
