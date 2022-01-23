using EmployeesDepartments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class EFDepartmentRepository : IDepartmentRepository
    {
        private EFDbContext _context;

        public EFDepartmentRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddDepartmentAsync(DepartmentModel newDepartment)
        {
            await _context.Departments.AddAsync(newDepartment);
            await _context.SaveChangesAsync();

            return newDepartment.DepartmentId;
        }

        public bool CheckIfDepartmentExist(int departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            return department == null ? false : true;
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task<ICollection<DepartmentModel>> GetDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<ICollection<DepartmentModel>> GetDepartmentsGroupByIdsAsync(ICollection<int> departmentsIds)
        {
            return await _context.Departments.Where(z => departmentsIds.Contains(z.DepartmentId)).ToListAsync();
        }

        public void RemoveDepartment(DepartmentModel department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(DepartmentModel updatedDepartment)
        {
            _context.Departments.Update(updatedDepartment);
            _context.SaveChanges();
        }
    }
}
