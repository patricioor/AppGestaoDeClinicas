using GeCli.Back.Domain.Entities;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Command
{
    public class DentistCommand : IRequest<Dentist>
    {
        public string Name { get; set; }
        public string Cro { get; set; }
        public int EmploymentId { get; set; }
    }
}
