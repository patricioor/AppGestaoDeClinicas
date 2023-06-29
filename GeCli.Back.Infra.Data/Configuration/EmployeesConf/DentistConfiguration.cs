using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.EmployeesConf
{
    public class DentistConfiguration : IEntityTypeConfiguration<Dentist>
    {
        public void Configure(EntityTypeBuilder<Dentist> builder)
        {
            builder.Property(p => p.Gender).HasConversion(
                p => p.ToString(),
                p => (Gender)Enum.Parse(typeof(Gender), p)
                );
        }
    }
}
