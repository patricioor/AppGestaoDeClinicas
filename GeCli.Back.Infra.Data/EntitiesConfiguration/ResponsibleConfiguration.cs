﻿using GeCli.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeCli.Back.Infra.Data.EntitiesConfiguration
{
    public class ResponsibleConfiguration : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(new Responsible(1, "Patricio Osterno Rios"),
                            new Responsible(2, "Teste Testerson da Silva"));
        }
    }
}