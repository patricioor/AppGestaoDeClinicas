using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private IMedicalRecordRepository _medicalRecordRepository;
        private readonly IMapper _mapper;
        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsAsync()
        {
            var record = await _medicalRecordRepository.GetMedicalRecordsAsync();
            return _mapper.Map<IEnumerable<MedicalRecordDTO>>(record);
        }

        public async Task<MedicalRecordDTO> GetMedicalRecordByIdAsync(int id)
        {
            var record = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id);
            return _mapper.Map<MedicalRecordDTO>(record);
        }

        public async Task CreateMedicalRecordAsync(MedicalRecordDTO medRecord)
        {
            var record = _mapper.Map<MedicalRecord>(medRecord);
            await _medicalRecordRepository.Create(record);
        }

        public async Task UpdateMedicalRecordAsync(MedicalRecordDTO medRecord)
        {
            var record = _mapper.Map<MedicalRecord>(medRecord);
            await _medicalRecordRepository.Update(record);
        }
        public async Task DeleteMedicalRecordAsync(int id)
        {
            var record = _medicalRecordRepository.GetMedicalRecordByIdAsync(id).Result;
            await _medicalRecordRepository.Remove(record);
        }
    }
}
