using GeCli.Back.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.EmployeesConf
{
    public class DentistSpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
