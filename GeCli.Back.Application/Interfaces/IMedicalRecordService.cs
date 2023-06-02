using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecordsAsync();
        Task<MedicalRecordDTO> GetMedicalRecordByIdAsync(int id);

        Task CreateMedicalRecordAsync(MedicalRecordDTO medRecord);
        Task UpdateMedicalRecordAsync(MedicalRecordDTO medRecord);
        Task DeleteMedicalRecordAsync(int id);
    }
}
