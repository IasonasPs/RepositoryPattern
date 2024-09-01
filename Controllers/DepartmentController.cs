using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;
using RepositoryPattern.Repository.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/{Controller}")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(_departmentRepository.GetDepartments());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int departmentId)
        {
            try
            {
                var result = _departmentRepository.GetDepartment(departmentId);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                var createdDepartment = await _departmentRepository.AddDepartment(department);
                return CreatedAtAction(nameof(GetDepartment), new { id = createdDepartment.DepartmentId }, createdDepartment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Department");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int departmentId, Department department)
        {
            try
            {
                if (departmentId != department.DepartmentId)
                {
                    return BadRequest("Department Id mismatch");
                }
                var departmentToUpdate = await _departmentRepository.GetDepartment(departmentId);
                if (departmentToUpdate == null)
                {
                    return NotFound($"Department with id = {departmentId} not found");
                }
                return await _departmentRepository.UpdateDepartment(departmentToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating department record");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {
            try
            {
                var departmentToDelete = await _departmentRepository.GetDepartment(departmentId);
                if (departmentToDelete == null)
                {
                    return NotFound($"Department with id = {departmentId} not found");
                }

                await _departmentRepository.DeleteDepartment(departmentId);
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError , "Error deleting data");
            }
        }
    }
}
