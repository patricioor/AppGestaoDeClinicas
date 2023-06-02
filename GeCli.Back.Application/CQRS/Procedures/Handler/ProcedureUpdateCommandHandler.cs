using GeCli.Back.Application.CQRS.Procedures.Command;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Application.CQRS.Procedures.Handler
{
    public class ProcedureUpdateCommandHandler : IRequestHandler<ProcedureUpdateCommand, Procedure>
    {
        private IProcedureRepository _procedureRepository;

        public ProcedureUpdateCommandHandler(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        public async Task<Procedure> Handle(ProcedureUpdateCommand request, CancellationToken cancellationToken)
        {
            var procedure = await _procedureRepository.GetProcedureByIdAsync(request.Id);
            if (procedure == null)
            {
                throw new ArgumentNullException("Error could not be found.");
            }
            else
            {
                procedure.Update(request.Name, request.ConsumableId);
                return await _procedureRepository.Update(procedure);
            }
        }
    }
}
