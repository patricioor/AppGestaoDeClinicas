using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Cro).HasMaxLength(5).IsRequired();

            builder.HasOne(e => e.Employment).WithMany(e => e.Dentists).HasForeignKey(e => e.EmploymentId);
        }
    }
}
