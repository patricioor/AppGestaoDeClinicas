using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Entities.Consumable;
using GeCli.Back.Domain.Entities.Customers;
using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Category
    public DbSet<Category> Categories { get; set; }
    // Consumable
    public DbSet<Consumable> Consumables { get; set; }
    //Customer
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomersAdresses { get; set; }
    public DbSet<CustomerCellphone> CustomersCellphones { get; set; }
    // Dentist
    public DbSet<Dentist> Dentists { get; set; }
    public DbSet<DentistAddress> DentistsAdresses { get; set; }
    public DbSet<DentistCellphone> DentistsCellphones { get; set; }
    // Specialtys
    public DbSet<Specialty> Specialtys { get; set; }
    public DbSet<Employment> Employments { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Procedure> Procedures { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    // User
    public DbSet<User> DbUsers { get; set; }
    public DbSet<Function> Functions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
