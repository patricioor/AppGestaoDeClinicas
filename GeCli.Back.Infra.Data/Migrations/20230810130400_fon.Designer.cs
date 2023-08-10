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
    [Migration("20230810130400_fon")]
    partial class fon
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ConsumableSupplier", b =>
                {
                    b.Property<int>("ConsumablesId")
                        .HasColumnType("int");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.HasKey("ConsumablesId", "SuppliersId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("ConsumableSupplier");
                });

            modelBuilder.Entity("DentistSpecialty", b =>
                {
                    b.Property<int>("DentistsId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtiesId")
                        .HasColumnType("int");

                    b.HasKey("DentistsId", "SpecialtiesId");

                    b.HasIndex("SpecialtiesId");

                    b.ToTable("DentistSpecialty");
                });

            modelBuilder.Entity("FunctionUser", b =>
                {
                    b.Property<int>("FunctionsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersLogin")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FunctionsId", "UsersLogin");

                    b.HasIndex("UsersLogin");

                    b.ToTable("FunctionUser");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumables.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumables.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int?>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProcedureId");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResponsibleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponsibleId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.CustomerAddress", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("CustomersAdresses");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.CustomerCellphone", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId", "Number");

                    b.ToTable("CustomersCellphones");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.Dentist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CRO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmploymentId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentId");

                    b.ToTable("Dentists");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.DentistAddress", b =>
                {
                    b.Property<int>("DentistId")
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DentistId");

                    b.ToTable("DentistsAdresses");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.DentistCellphone", b =>
                {
                    b.Property<int>("DentistId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DentistId", "Number");

                    b.ToTable("DentistsCellphones");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialtys");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Employments");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Allergy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Bleed")
                        .HasColumnType("bit");

                    b.Property<string>("Complaint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DentistId")
                        .HasColumnType("int");

                    b.Property<string>("Disease")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Heal")
                        .HasColumnType("bit");

                    b.Property<string>("MedRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Medicate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcedureId")
                        .HasColumnType("int");

                    b.Property<string>("Surgery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DentistId");

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

                    b.HasKey("Id");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Responsible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Responsibles");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.SupplierAddress", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("SupplierAddresses");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.SupplierCellphone", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SupplierId", "Number");

                    b.ToTable("SupplierCellphones");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.User.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.User.User", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Login");

                    b.ToTable("DbUsers");
                });

            modelBuilder.Entity("ConsumableSupplier", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Consumables.Consumable", null)
                        .WithMany()
                        .HasForeignKey("ConsumablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Suppliers.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DentistSpecialty", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Employees.Dentist", null)
                        .WithMany()
                        .HasForeignKey("DentistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Employees.Specialty", null)
                        .WithMany()
                        .HasForeignKey("SpecialtiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FunctionUser", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.User.Function", null)
                        .WithMany()
                        .HasForeignKey("FunctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.User.User", null)
                        .WithMany()
                        .HasForeignKey("UsersLogin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumables.Consumable", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Consumables.Category", "Category")
                        .WithMany("Consumables")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Procedure", null)
                        .WithMany("Consumables")
                        .HasForeignKey("ProcedureId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.Customer", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Responsible", null)
                        .WithMany("Customers")
                        .HasForeignKey("ResponsibleId");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.CustomerAddress", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Customers.Customer", "Customer")
                        .WithOne("Address")
                        .HasForeignKey("GeCli.Back.Domain.Entities.Customers.CustomerAddress", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.CustomerCellphone", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Cellphones")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.Dentist", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Employment", null)
                        .WithMany("Dentists")
                        .HasForeignKey("EmploymentId");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.DentistAddress", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Employees.Dentist", "Dentist")
                        .WithOne("Address")
                        .HasForeignKey("GeCli.Back.Domain.Entities.Employees.DentistAddress", "DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.DentistCellphone", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Employees.Dentist", "Dentist")
                        .WithMany("Cellphones")
                        .HasForeignKey("DentistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentist");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.MedicalRecord", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeCli.Back.Domain.Entities.Employees.Dentist", "Dentist")
                        .WithMany()
                        .HasForeignKey("DentistId")
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

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.SupplierAddress", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Suppliers.Supplier", "Supplier")
                        .WithOne("Address")
                        .HasForeignKey("GeCli.Back.Domain.Entities.Suppliers.SupplierAddress", "SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.SupplierCellphone", b =>
                {
                    b.HasOne("GeCli.Back.Domain.Entities.Suppliers.Supplier", "Supplier")
                        .WithMany("Cellphones")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Consumables.Category", b =>
                {
                    b.Navigation("Consumables");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cellphones");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employees.Dentist", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cellphones");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Employment", b =>
                {
                    b.Navigation("Dentists");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Procedure", b =>
                {
                    b.Navigation("Consumables");

                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Responsible", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("GeCli.Back.Domain.Entities.Suppliers.Supplier", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cellphones");
                });
#pragma warning restore 612, 618
        }
    }
}
