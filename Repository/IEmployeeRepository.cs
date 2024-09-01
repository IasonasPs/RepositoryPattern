using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;

namespace RepositoryPattern.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
