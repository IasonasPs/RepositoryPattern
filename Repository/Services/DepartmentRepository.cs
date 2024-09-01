using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDbContext appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await appDbContext.Departments.ToListAsync();
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            var result = await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            return result;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            var result = await appDbContext.Departments.AddAsync(department);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var result = await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == department.DepartmentId);
            if (result != null)
            {
                result.DepartmentName = department.DepartmentName;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null!;
        }

        public async Task DeleteDepartment(int departmentId)
        {
            var departmentToDelete = await appDbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (departmentToDelete != null)
            {
                appDbContext.Departments.Remove(departmentToDelete);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
