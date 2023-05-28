using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Consumable, ConsumableDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Dentist, DentistDTO>().ReverseMap();
            CreateMap<Employment, EmploymentDTO>().ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordDTO>().ReverseMap();
            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<Responsible, ResponsibleDTO>().ReverseMap();
        }
    }
}
