using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.Employees
{
    public class DentistAddressConfiguration : IEntityTypeConfiguration<DentistAddress>
    {
        public void Configure(EntityTypeBuilder<DentistAddress> builder)
        {
            builder.HasKey(p => new { p.DentistId });
            builder.Property(p => p.State).HasConversion(
            p => p.ToString(),
            p => (State)Enum.Parse(typeof(State), p)
            );
        }
    }
}
