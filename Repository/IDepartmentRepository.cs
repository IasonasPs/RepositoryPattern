using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task DeleteDepartment(int departmentId);
    }
}
