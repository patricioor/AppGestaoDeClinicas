using GeCli.Back.Application.CQRS.Procedures.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;

namespace GeCli.Back.Application.CQRS.Procedures.Handler
{
    public class ProcedureRemoveCommandHandler : IRequestHandler<ProcedureRemoveCommand, Procedure>
    {
        private IProcedureRepository _procedureRepository;

        public ProcedureRemoveCommandHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<Procedure> Handle(ProcedureRemoveCommand request, CancellationToken cancellationToken)
        {
            var procedure = await _procedureRepository.GetProcedureById(request.Id);
            if (procedure == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                var result = await _procedureRepository.Remove(procedure);
                return result;
            }
        }
    }
}
