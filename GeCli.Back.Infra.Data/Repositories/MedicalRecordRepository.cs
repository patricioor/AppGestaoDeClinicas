﻿using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class MedicalRecordRepository : IMedicalRecorderRepository
    {
        ApplicationDbContext _medicalRecordContext;

        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _medicalRecordContext = context;
        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecords()
        {
            return await _medicalRecordContext.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordById(int? id)
        {
            return await _medicalRecordContext.MedicalRecords.FindAsync(id);
        }

        public async Task<MedicalRecord> Create(MedicalRecord record)
        {
            _medicalRecordContext.MedicalRecords.Add(record);
            await _medicalRecordContext.SaveChangesAsync();
            return record;
        }

        public async Task<MedicalRecord> Update(MedicalRecord record)
        {
            _medicalRecordContext.MedicalRecords.Update(record);
            await _medicalRecordContext.SaveChangesAsync();
            return record;
        }

        public async Task<MedicalRecord> Remove(MedicalRecord record)
        {
            _medicalRecordContext.MedicalRecords.Remove(record);
            await _medicalRecordContext.SaveChangesAsync();
            return record;
        }
    }
}
