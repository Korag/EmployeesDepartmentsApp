using EmployeesDepartments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class EFDepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private EFDbContext _context;

        public EFDepartmentEmployeeRepository(EFDbContext context)
        {
            _context = context;
        }

        public void AssignEmployeeToDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.DepartmentEmployees.Add(departmentEmployee);
            _context.SaveChanges();
        }

        public bool CheckIfUserBelongsToDepartment(int employeeId, int departmentId)
        {
            if (_context.DepartmentEmployees.Where(z => z.EmployeeId == employeeId && z.DepartmentId == departmentId).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ICollection<EmployeeModel>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            //var departmentId = _context.Departments.Where(z => z.Name == departmentName).FirstOrDefault().DepartmentId;
            //var employeesIds = _context.DepartmentEmployees.Where(z => z.DepartmentId == departmentId).Select(x => x.EmployeeId).ToList();
            //return await _context.Employees.Where(z => employeesIds.Contains(z.EmployeeId)).ToListAsync();

            return await _context.DepartmentEmployees.Include(z => z.Department).Include(z => z.Employee).Where(z => z.Department.Name == departmentName).Select(z => z.Employee).ToListAsync();
        }

        public async Task<ICollection<DepartmentModel>> GetEmployeesDepartmentsAsync(int employeeId)
        {
            //var departmentsIds = _context.DepartmentEmployees.Where(z => z.EmployeeId == employeeId).Select(z => z.DepartmentId).ToList();
            //return await _context.Departments.Where(z => departmentsIds.Contains(z.DepartmentId)).ToListAsync();

            return await _context.DepartmentEmployees.Include(z => z.Department).Include(z => z.Employee).Where(z => z.Employee.EmployeeId == employeeId).Select(z => z.Department).ToListAsync();
        }

        public void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.DepartmentEmployees.Remove(departmentEmployee);
            _context.SaveChanges();
        }
    }
}
