using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Cellphone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Birth).HasMaxLength(8).IsRequired();
            builder.Property(p => p.Responsible).IsRequired().HasColumnType("bit");

            builder.HasOne(e => e.Responsible).WithOne(e => e.Customer).HasForeignKey<Customer>(e => e.ResponsibleId);
        }
    }
}
