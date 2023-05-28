using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Command
{
    public class DentistUpdateCommand : DentistCommand
    {
        public int Id { get; set; }
    }
}
