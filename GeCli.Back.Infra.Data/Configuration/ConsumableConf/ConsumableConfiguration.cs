using GeCli.Back.Domain.Entities.Consumables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.ConsumableConf;

public class ConsumableConfiguration : IEntityTypeConfiguration<Consumable>
{
    public void Configure(EntityTypeBuilder<Consumable> builder)
    {
        builder.Property(p => p.Price).HasPrecision(8, 2);
    }
}
