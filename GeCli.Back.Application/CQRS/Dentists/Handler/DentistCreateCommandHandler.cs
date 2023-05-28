using GeCli.Back.Application.CQRS.Dentists.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Handler
{
    public class DentistCreateCommandHandler : IRequestHandler<DentistCreateCommand, Dentist>
    {
        private IDentistRepository _dentistRepository;
        public DentistCreateCommandHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }
        public async Task<Dentist> Handle(DentistCreateCommand request, CancellationToken cancellationToken)
        {
            var dentist = new Dentist(request.Name, request.Cro);

            if(dentist == null)
            {
                throw new ArgumentNullException("Error creating entity.");
            }

            dentist.EmploymentId = request.EmploymentId;
            return await _dentistRepository.Create(dentist);
        }
    }
}
