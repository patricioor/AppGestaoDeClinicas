using GeCli.Back.Domain.Entities.Employees;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeCli.Back.Infra.Data.Repositories
{
    public class EmploymentRepository : IEmploymentRepository
    {
        readonly ApplicationDbContext _employmentContext;
        public EmploymentRepository(ApplicationDbContext context)
        {
            _employmentContext = context;
        }

        public async Task<ICollection<Employment>> GetEmploymentsAsync()
        {
            return await _employmentContext.Employments.AsNoTracking().ToListAsync();
        }

        public async Task<Employment> GetEmploymentByIdAsync(int id)
        {
            return await _employmentContext.Employments.FindAsync();
        }

        public async Task<Employment> Create(Employment employment)
        {
            _employmentContext.Employments.Add(employment);
            await _employmentContext.SaveChangesAsync();
            return employment;
        }

        public async Task<Employment> Update(Employment employment)
        {
            _employmentContext.Employments.Update(employment);
            await _employmentContext.SaveChangesAsync();
            return employment;
        }
        public async Task<Employment> Remove(Employment employment)
        {
            _employmentContext.Employments.Remove(employment);
            await _employmentContext.SaveChangesAsync();
            return employment;
        }
    }
}
