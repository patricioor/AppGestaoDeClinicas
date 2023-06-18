using GeCli.Back.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration
{
    public class CellphoneConfiguration : IEntityTypeConfiguration<Cellphone>
    {
        public void Configure(EntityTypeBuilder<Cellphone> builder)
        {
            builder.HasKey(p => new { p.CustomerId, p.Number });
        }
    }
}
