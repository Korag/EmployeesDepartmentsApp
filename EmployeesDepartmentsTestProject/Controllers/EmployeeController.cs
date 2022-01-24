using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartments.DataAccess.Repositories;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartmentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<ICollection<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepo.GetEmployeesAsync();
            var employeesDto = _mapper.Map<ICollection<EmployeeDto>>(employees).ToList();

            return Ok(employeesDto);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepo.GetEmployeeByIdAsync(id);

            if (employee == null)
                return NotFound();
            
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDto);
        }

        // GET: api/Employee/Multiple
        [HttpGet("Multiple")]
        public async Task<ActionResult<ICollection<EmployeeDto>>> GetEmployees([FromBody] ICollection<int> ids)
        {
            var employees = await _employeeRepo.GetEmployeesGroupByIdsAsync(ids);
            var employeesDto = _mapper.Map<ICollection<EmployeeDto>>(employees).ToList();

            return Ok(employeesDto);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepo.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepo.RemoveEmployee(employee);
            return NoContent();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto employee)
        {
            if (id != employee.EmployeeId || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEmployee = await _employeeRepo.GetEmployeeByIdAsync(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee = _mapper.Map<UpdateEmployeeDto, EmployeeModel>(employee, existingEmployee);
            _employeeRepo.UpdateEmployee(existingEmployee);

            return NoContent();
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(CreateEmployeeDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployee = _mapper.Map<EmployeeModel>(employee);
            
            try
            {
                createdEmployee.EmployeeId = await _employeeRepo.AddEmployeeAsync(createdEmployee);
            }
            catch (DbUpdateException)
            {
                if (_employeeRepo.CheckIfEmployeeExist(createdEmployee.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var employeeDto = _mapper.Map<EmployeeDto>(createdEmployee);

            return CreatedAtAction("GetEmployee", new { id = createdEmployee.EmployeeId }, employeeDto);
        }
    }
}
