using GeCli.Back.Application.DTOs;

namespace GeCli.Back.Application.Interfaces
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecordDTO>> GetMedicalRecords();
        Task<MedicalRecordDTO> GetMedicalRecordById(int? id);

        Task Create(MedicalRecordDTO medRecord);
        Task Update(MedicalRecordDTO medRecord);
        Task Delete(int? id);
    }
}
