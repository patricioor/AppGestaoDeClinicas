using GeCli.Back.Application.CQRS.Procedures.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Handler
{
    public class ProcedureCreateCommandHandler : IRequestHandler<ProcedureCreateCommand, Procedure>
    {
        private IProcedureRepository _procedureRepository;

        public ProcedureCreateCommandHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        async Task<Procedure> IRequestHandler<ProcedureCreateCommand, Procedure>.Handle(ProcedureCreateCommand request, CancellationToken cancellationToken)
        {
            var procedure = new Procedure(request.Name);
            if (procedure == null)
            {
                throw new ArgumentNullException("Error creating entity.");
            }
            else
            {
                procedure.ConsumableId = request.ConsumableId;
                return await _procedureRepository.Create(procedure);
            }
        }
    }
}
