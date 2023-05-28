using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Command
{
    public class DentistRemoveCommand : IRequest<Dentist>
    {
        public int Id { get; set; }
        public DentistRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
