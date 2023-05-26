using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new Category(1, "Limpeza"),
                            new Category(2, "Descartáveis"));
        }
    }
}
