using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<ICollection<MedicalRecord>> GetMedicalRecordsAsync();
        Task<MedicalRecord> GetMedicalRecordByIdAsync(int id);

        Task<MedicalRecord> Create(MedicalRecord record);
        Task<MedicalRecord> Update(MedicalRecord record);
        Task<MedicalRecord> Remove(MedicalRecord record);
    }
}
