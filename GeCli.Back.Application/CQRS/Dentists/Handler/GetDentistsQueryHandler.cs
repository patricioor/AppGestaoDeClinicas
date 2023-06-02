using GeCli.Back.Application.CQRS.Dentists.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Dentists.Handler
{
    public class GetDentistsQueryHandler : IRequestHandler<GetDentistsQuery, IEnumerable<Dentist>>
    {
        private IDentistRepository _dentistRepository;

        public GetDentistsQueryHandler(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public async Task<IEnumerable<Dentist>> Handle(GetDentistsQuery request, CancellationToken cancellationToken)
        {
            return await _dentistRepository.GetDentistsAsync();
        }
    }
}
