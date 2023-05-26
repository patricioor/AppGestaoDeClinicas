using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class MedicalRecorderConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Complaint).HasMaxLength(1000).IsRequired();
            builder.Property(p => p.Medicate).HasMaxLength(100);
            builder.Property(p => p.Allergy).HasMaxLength(100);
            builder.Property(p => p.Disease).HasMaxLength(100);
            builder.Property(p => p.Surgery).HasMaxLength(100);
            builder.Property(p => p.Bleed).IsRequired().HasColumnType("bit");
            builder.Property(p => p.Heal).IsRequired().HasColumnType("bit");
            builder.Property(p => p.MedRecord).HasMaxLength(5000).IsRequired();

            builder.HasOne(e => e.Procedure).WithOne(e => e.MedicalRecord).HasForeignKey<MedicalRecord>(e => e.ProcedureId);
            builder.HasOne(e => e.Dentist).WithOne(e => e.MedicalRecord).HasForeignKey<MedicalRecord>(e => e.DentistId);
            builder.HasOne(e => e.Customer).WithOne(e => e.MedicalRecord).HasForeignKey<MedicalRecord>(e => e.CustomerId);
        }
    }
}
