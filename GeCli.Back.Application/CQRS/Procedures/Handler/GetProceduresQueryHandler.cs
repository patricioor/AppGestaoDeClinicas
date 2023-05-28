using GeCli.Back.Application.CQRS.Procedures.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Handler
{
    public class GetProceduresQueryHandler : IRequestHandler<GetProceduresQuery, IEnumerable<Procedure>>
    {
        private IProcedureRepository _procedureRepository;

        public GetProceduresQueryHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<IEnumerable<Procedure>> Handle(GetProceduresQuery request, CancellationToken cancellationToken)
        {
            return await _procedureRepository.GetProcedures();
        }
    }
}
