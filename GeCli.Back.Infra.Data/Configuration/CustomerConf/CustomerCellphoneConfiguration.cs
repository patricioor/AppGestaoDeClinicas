using GeCli.Back.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.CustomerConf
{
    public class CustomerCellphoneConfiguration : IEntityTypeConfiguration<CustomerCellphone>
    {
        public void Configure(EntityTypeBuilder<CustomerCellphone> builder)
        {
            builder.HasKey(p => new { p.CustomerId, p.Number});
        }
    }
}
