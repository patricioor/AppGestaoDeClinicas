using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasOne(e=> e.Consumable).WithMany(e=> e.Procedures).HasForeignKey(p => p.ConsumableId);
        }
    }
}
