using GeCli.Back.Domain.Entities;

namespace GeCli.Back.Domain.Interfaces
{
    public interface IMedicalRecorderRepository
    {
        Task<IEnumerable<MedicalRecord>> GetMedicalRecords();
        Task<MedicalRecord> GetMedicalRecordById();

        Task<MedicalRecord> Create(MedicalRecord record);
        Task<MedicalRecord> Update(MedicalRecord record);
        Task<MedicalRecord> Remove(MedicalRecord record);
    }
}
