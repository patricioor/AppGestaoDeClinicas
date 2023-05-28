﻿using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class ResponsibleService : IResponsibleService
    {
        private IResponsibleRepository _responsibleRepository;
        private readonly IMapper _mapper;
        public ResponsibleService(IResponsibleRepository responsibleRepository, IMapper mapper)
        {
            _responsibleRepository = responsibleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResponsibleDTO>> GetResponsible()
        {
            var responsible = await _responsibleRepository.GetResponsibles();
            return _mapper.Map<IEnumerable<ResponsibleDTO>>(responsible);
        }

        public async Task<ResponsibleDTO> GetResponsibleById(int? id)
        {
            var responsible = await _responsibleRepository.GetResponsiblesById(id);
            return _mapper.Map<ResponsibleDTO>(responsible);
        }

        public async Task Create(ResponsibleDTO responsibleDTO)
        {
            var responsible = _mapper.Map<Responsible>(responsibleDTO);
            await _responsibleRepository.Create(responsible);
        }

        public async Task Update(ResponsibleDTO responsibleDTO)
        {
            var responsible = _mapper.Map<Responsible>(responsibleDTO);
            await _responsibleRepository.Update(responsible);
        }

        public async Task Delete(int? id)
        {
            var responsible = _responsibleRepository.GetResponsiblesById(id).Result;
            await _responsibleRepository.Remove(responsible);
        }
    }
}
