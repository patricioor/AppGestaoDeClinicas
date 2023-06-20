using Microsoft.EntityFrameworkCore;
using GeCli.Back.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.Employees
{
    public class DentistCellphoneConfiguration : IEntityTypeConfiguration<DentistCellphone>
    {
        public void Configure(EntityTypeBuilder<DentistCellphone> builder)
        {
           builder.HasKey(p => new { p.DentistId, p.Number });
        }
    }
}
