﻿using GeCli.Back.Domain.Entities.AbstractClasses;
using GeCli.Back.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.Configuration.CustomerConf
{
    public class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasKey(p => p.CustomerId);
            builder.Property(p => p.State).HasConversion(
                p => p.ToString(),
                p => (State)Enum.Parse(typeof(State),p)
                );
        }
    }
}
