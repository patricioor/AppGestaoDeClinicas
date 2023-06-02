using GeCli.Back.Application.CQRS.Dentists.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Handler
{
    public class DentistRemoveCommandHandler : IRequestHandler<DentistRemoveCommand, Dentist>
    {
        private IDentistRepository _dentistRepository;

        public DentistRemoveCommandHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public async Task<Dentist> Handle(DentistRemoveCommand request, CancellationToken cancellationToken)
        {
            var dentist = await _dentistRepository.GetDentistByIdAsync(request.Id);

            if(dentist == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                var result = await _dentistRepository.Remove(dentist);
                return result;
            }
        }
    }
}
