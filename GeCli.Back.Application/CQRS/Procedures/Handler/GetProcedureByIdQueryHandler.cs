using GeCli.Back.Application.CQRS.Procedures.Query;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Handler
{
    public class GetProcedureByIdQueryHandler : IRequestHandler<GetProcedureByIdQuery, Procedure>
    {
        private IProcedureRepository _procedureRepository;

        public GetProcedureByIdQueryHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<Procedure> Handle(GetProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            return await _procedureRepository.GetProcedureByIdAsync(request.Id);
        }
    }
}
