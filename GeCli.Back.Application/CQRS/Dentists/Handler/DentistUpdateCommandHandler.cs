using GeCli.Back.Application.CQRS.Dentists.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Application.CQRS.Dentists.Handler
{
    public class DentistUpdateCommandHandler : IRequestHandler<DentistUpdateCommand, Dentist>
    {
        private IDentistRepository _dentistRepository;

        public DentistUpdateCommandHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public async Task<Dentist> Handle(DentistUpdateCommand request, CancellationToken cancellationToken)
        {
            var dentist = await _dentistRepository.GetDentistByIdAsync(request.Id);

            if(dentist == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                dentist.Update(request.Name, request.Cro, request.EmploymentId);
                return await _dentistRepository.Update(dentist);
            }

        }
    }
}
