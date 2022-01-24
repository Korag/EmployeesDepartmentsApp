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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<ICollection<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentRepo.GetDepartmentsAsync();
            var departmentsDto = _mapper.Map<ICollection<DepartmentDto>>(departments).ToList();

            return Ok(departmentsDto);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await _departmentRepo.GetDepartmentByIdAsync(id);

            if (department == null)
                return NotFound();

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return Ok(departmentDto);
        }

        // GET: api/Department/Multiple
        [HttpGet("Multiple")]
        public async Task<ActionResult<ICollection<DepartmentDto>>> GetDepartments([FromBody] ICollection<int> ids)
        {
            var departments = await _departmentRepo.GetDepartmentsGroupByIdsAsync(ids);
            var departmentsDto = _mapper.Map<ICollection<DepartmentDto>>(departments).ToList();

            return Ok(departmentsDto);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepo.GetDepartmentByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            _departmentRepo.RemoveDepartment(department);
            return NoContent();
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto department)
        {
            if (id != department.DepartmentId || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDepartment = await _departmentRepo.GetDepartmentByIdAsync(id);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment = _mapper.Map<UpdateDepartmentDto, DepartmentModel>(department, existingDepartment);
            _departmentRepo.UpdateDepartment(existingDepartment);

            return NoContent();
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(CreateDepartmentDto department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdDepartment = _mapper.Map<DepartmentModel>(department);

            try
            {
                createdDepartment.DepartmentId = await _departmentRepo.AddDepartmentAsync(createdDepartment);
            }
            catch (DbUpdateException)
            {
                if (_departmentRepo.CheckIfDepartmentExist(createdDepartment.DepartmentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var departmentDto = _mapper.Map<DepartmentDto>(createdDepartment);

            return CreatedAtAction("GetDepartment", new { id = createdDepartment.DepartmentId }, departmentDto);
        }
    }
}
