using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartments.DataAccess.Repositories;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartmentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentEmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IDepartmentRepository _departmentRepo;

        private readonly IDepartmentEmployeeRepository _departmentEmployeeRepo;
        private readonly IMapper _mapper;

        public DepartmentEmployeeController(IDepartmentEmployeeRepository departmentEmployeeRepo, IDepartmentRepository departmentRepo, IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _departmentEmployeeRepo = departmentEmployeeRepo;
            _departmentRepo = departmentRepo;
            _employeeRepo = employeeRepo;

            _mapper = mapper;
        }

        // GET: api/DepartmentEmployee
        [HttpGet]
        public async Task<ActionResult<ICollection<EmployeeDepartmentsDto>>> GetEmployeeDepartments()
        {
            var employess = await _employeeRepo.GetEmployeesAsync();

            List<EmployeeDepartmentsDto> employeesWDepartments = new List<EmployeeDepartmentsDto>();

            foreach (var employee in employess)
            {
                var employeeDepartments = await _departmentEmployeeRepo.GetEmployeesDepartmentsAsync(employee.EmployeeId);

                var employeeDepartmentsDto = _mapper.Map<EmployeeDepartmentsDto>(employee);
                employeeDepartmentsDto.Departments = _mapper.Map<ICollection<DepartmentDto>>(employeeDepartments);

                employeesWDepartments.Add(employeeDepartmentsDto);
            }

            return Ok(employeesWDepartments);
        }

        // GET: api/DepartmentEmployee/Employee/5
        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<EmployeeDepartmentsDto>> GetEmployeeDepartments(int id)
        {
            var employee = await _employeeRepo.GetEmployeeByIdAsync(id);

            if (employee == null)
                return NotFound();

            var employeeDepartments = await _departmentEmployeeRepo.GetEmployeesDepartmentsAsync(id);

            var employeeDepartmentsDto = _mapper.Map<EmployeeDepartmentsDto>(employee);
            employeeDepartmentsDto.Departments = _mapper.Map<ICollection<DepartmentDto>>(employeeDepartments);

            return Ok(employeeDepartmentsDto);
        }

        // GET: api/DepartmentEmployee/Department/5
        [HttpGet("Department/{id}")]
        public async Task<ActionResult<DepartmentEmployeesDto>> GetDepartmentEmployees(int id)
        {
            var department = await _departmentRepo.GetDepartmentByIdAsync(id);

            if (department == null)
                return NotFound();

            var departmentEmployees = await _departmentEmployeeRepo.GetEmployeesByDepartmentIdAsync(id);

            var departmentEmployeesDto = _mapper.Map<DepartmentEmployeesDto>(department);
            departmentEmployeesDto.Employees = _mapper.Map<ICollection<EmployeeDto>>(departmentEmployees);

            return Ok(departmentEmployeesDto);
        }

        // DELETE: api/DepartmentEmployee
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartmentEmployee(DeleteDepartmentEmployeeDto departmentEmployee)
        {
            var employee = await _employeeRepo.GetEmployeeByIdAsync(departmentEmployee.EmployeeId);

            if (employee != null)
            {
                var employeeDepartments = await _departmentEmployeeRepo.GetEmployeesDepartmentsAsync(departmentEmployee.EmployeeId);

                if (employeeDepartments.Select(z => z.DepartmentId).ToList().Contains(departmentEmployee.DepartmentId))
                {
                    var deleteDepartmentFromEmployee = _mapper.Map<DepartmentEmployeeModel>(departmentEmployee);

                    _departmentEmployeeRepo.RemoveEmployeeFromDepartment(deleteDepartmentFromEmployee);
                    return NoContent();
                }

                return NotFound();
            }

            return NoContent();
        }

        // POST: api/DepartmentEmployee
        [HttpPost]
        public async Task<ActionResult<EmployeeDepartmentsDto>> PostDepartmentEmployee(CreateDepartmentEmployeeDto departmentEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _employeeRepo.GetEmployeeByIdAsync(departmentEmployee.EmployeeId);
            var department = await _departmentRepo.GetDepartmentByIdAsync(departmentEmployee.DepartmentId);

            if (employee != null && department != null)
            {
                try
                {
                    var newDepartmentEmployee = _mapper.Map<DepartmentEmployeeModel>(departmentEmployee);
                    _departmentEmployeeRepo.AssignEmployeeToDepartment(newDepartmentEmployee);
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }

            var employeeDepartments = await _departmentEmployeeRepo.GetEmployeesDepartmentsAsync(departmentEmployee.EmployeeId);

            var employeeDepartmentsDto = _mapper.Map<EmployeeDepartmentsDto>(employee);
            employeeDepartmentsDto.Departments = _mapper.Map<ICollection<DepartmentDto>>(employeeDepartments);

            return CreatedAtAction("GetEmployeeDepartments", new { id = employeeDepartmentsDto.EmployeeId }, employeeDepartmentsDto);
        }
    }
}