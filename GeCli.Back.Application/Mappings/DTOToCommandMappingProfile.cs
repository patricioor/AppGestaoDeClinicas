using AutoMapper;
using GeCli.Back.Application.CQRS.Consumables.Commands;
using GeCli.Back.Application.CQRS.Customers.Command;
using GeCli.Back.Application.CQRS.Dentists.Command;
using GeCli.Back.Application.CQRS.MedicalRecords.Command;
using GeCli.Back.Application.CQRS.Procedures.Command;
using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile() 
        {
            CreateMap<ConsumableDTO, ConsumableCreateCommand>();
            CreateMap<ConsumableDTO, ConsumableUpdateCommand>();
            CreateMap<CustomerDTO, CustomerCreateCommand>();
            CreateMap<CustomerDTO, CustomerUpdateCommand>();
            CreateMap<DentistDTO, DentistCreateCommand>();
            CreateMap<DentistDTO, DentistUpdateCommand>();
            CreateMap<MedicalRecordDTO, MedicalRecordCreateCommand>();
            CreateMap<MedicalRecordDTO, MedicalRecordUpdateCommand>();
            CreateMap<ProcedureDTO, ProcedureCreateCommand>();
            CreateMap<ProcedureDTO, ProcedureUpdateCommand>();
        }
    }
}
