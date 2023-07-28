using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.SupplierConf;

public class SupplierAddressConfiguration : IEntityTypeConfiguration<SupplierAddress>
{
    public void Configure(EntityTypeBuilder<SupplierAddress> builder)
    {
        builder.HasKey(p => new { p.SupplierId });
        builder.Property(p => p.State).HasConversion(
        p => p.ToString(),
        p => (State)Enum.Parse(typeof(State), p)
        );
    }
}
