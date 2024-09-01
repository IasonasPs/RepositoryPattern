using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        #region GET

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        #endregion

        #region POST
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
        #endregion

        #region PUT
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var employeeToUpdate = await _employeeRepository.GetEmployee(id);

                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating new employee record");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with id = {id} not found");
                }

                await _employeeRepository.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
        #endregion

    }
}
