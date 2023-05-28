using GeCli.Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Application.CQRS.Procedures.Query
{
    public class GetProcedureByIdQuery : IRequest<Procedure>
    {
        public int Id { get; set; }

        public GetProcedureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
