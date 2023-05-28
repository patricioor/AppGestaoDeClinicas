using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetMedicalRecords();
        Task<MedicalRecord> GetMedicalRecordById(int? id);

        Task<MedicalRecord> Create(MedicalRecord record);
        Task<MedicalRecord> Update(MedicalRecord record);
        Task<MedicalRecord> Remove(MedicalRecord record);
    }
}
