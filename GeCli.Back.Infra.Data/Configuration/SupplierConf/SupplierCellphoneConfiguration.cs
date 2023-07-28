using GeCli.Back.Domain.Entities.Suppliers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.SupplierConf
{
    public class SupplierCellphoneConfiguration : IEntityTypeConfiguration<SupplierCellphone>
    {
        public void Configure(EntityTypeBuilder<SupplierCellphone> builder)
        {
            builder.HasKey(p => new {p.SupplierId, p.Number});
        }
    }
}
