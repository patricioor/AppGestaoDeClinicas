using GeCli.Back.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeCli.Back.Infra.Data.Configuration.Employees
{
    public class DentistAddressConfiguration : IEntityTypeConfiguration<DentistAddress>
    {
        public void Configure(EntityTypeBuilder<DentistAddress> builder)
        {
            builder.HasKey(p => new { p.DentistId });
        }
    }
}
