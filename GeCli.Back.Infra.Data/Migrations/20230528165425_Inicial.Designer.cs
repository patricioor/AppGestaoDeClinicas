﻿// <auto-generated />
using System;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeCli.Back.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230528165425_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Limpeza"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Descartáveis"
                        });
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Birth")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Cellphone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ResponsibleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Dentist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cro")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("EmploymentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("Dentists");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sócio"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Prestador de Serviço"
                        });
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Allergy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Bleed")
                        .HasColumnType("bit");

                    b.Property<string>("Complaint")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DentistId")
                        .HasColumnType("int");

                    b.Property<string>("Disease")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Heal")
                        .HasColumnType("bit");

                    b.Property<string>("MedRecord")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicate")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("Surgery")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DentistId")
                        .IsUnique();

                    b.HasIndex("ProcedureId")
                        .IsUnique();

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConsumableId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ConsumableId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Responsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Responsibles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Patricio Osterno Rios"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Teste Testerson da Silva"
                        });
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumable", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Category", "Category")
                        .WithMany("Consumables")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customer", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Responsible", "Responsible")
                        .WithMany("Customers")
                        .HasForeignKey("ResponsibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsible");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Dentist", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Employment", "Employment")
                        .WithMany("Dentists")
                        .HasForeignKey("EmploymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employment");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.MedicalRecord", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Customer", "Customer")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Dentist", "Dentist")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("GeCli.Back.Domain.Entities.MedicalRecord", "DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Procedure", "Procedure")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("GeCli.Back.Domain.Entities.MedicalRecord", "ProcedureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Dentist");

                    b.Navigation("Procedure");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Procedure", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Consumable", "Consumable")
                        .WithMany("Procedures")
                        .HasForeignKey("ConsumableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumable");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Category", b =>
                {
                    b.Navigation("Consumables");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumable", b =>
                {
                    b.Navigation("Procedures");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customer", b =>
                {
                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Dentist", b =>
                {
                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employment", b =>
                {
                    b.Navigation("Dentists");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Procedure", b =>
                {
                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Responsible", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
