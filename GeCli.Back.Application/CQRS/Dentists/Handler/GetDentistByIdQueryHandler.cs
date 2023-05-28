using GeCli.Back.Application.CQRS.Dentists.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Handler
{
    public class GetDentistByIdQueryHandler : IRequestHandler<GetDentistByIdQuery, Dentist>
    {
        private IDentistRepository _dentistRepository;

        public GetDentistByIdQueryHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public async Task<Dentist> Handle(GetDentistByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dentistRepository.GetDentistById(request.Id);
        }
    }
}
