﻿using AutoMapper;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Employees;

namespace GeCli.Back.Manager.Implementation;

public class DentistManager : IDentistManager
{
    private readonly IDentistRepository _dentistRepository;
    private readonly IMapper _mapper;

    public DentistManager(IDentistRepository dentistRepository, IMapper mapper)
    {
        _dentistRepository = dentistRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<DentistView>> GetDentistsAsync()
    {
        return _mapper.Map<ICollection<DentistView>>(await _dentistRepository.GetDentistsAsync());
    }

    public async Task<DentistView> GetDentistByIdAsync(int id)
    {
        return _mapper.Map<DentistView>(await _dentistRepository.GetDentistByIdAsync(id));
    }

    public async Task<DentistView> InsertDentistAsync(NewDentist newDentist)
    {          
        var dentist = _mapper.Map<Dentist>(newDentist);
        return _mapper.Map<DentistView>(await _dentistRepository.InsertDentistAsync(dentist));
    }

    public async Task<DentistView> UpdateDentistAsync(UpdateDentist updateDentist)
    {
        var dentist = _mapper.Map<Dentist>(updateDentist);
        return _mapper.Map<DentistView>(await _dentistRepository.UpdateDentistAsync(dentist));
    }

    public async Task<DentistView> DeleteDentistAsync(int id)
    {
        var dentistDeleted = await _dentistRepository.DeleteDentistAsync(id);
        return _mapper.Map<DentistView>(dentistDeleted);
    }
}
