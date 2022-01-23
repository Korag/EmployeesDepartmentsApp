using EmployeesDepartments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            throw new NotImplementedException();
        }

        public async Task<ICollection<EmployeeModel>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            var departmentId = _context.Departments.Where(z => z.Name == departmentName).FirstOrDefault().DepartmentId;
            var employeesIds = _context.DepartmentEmployees.Where(z => z.DepartmentId == departmentId).Select(x => x.EmployeeId).ToList();
            return await _context.Employees.Where(z => employeesIds.Contains(z.EmployeeId)).ToListAsync();
        }

        public async Task<ICollection<DepartmentModel>> GetEmployeeDepartmentsAsync(int employeeId)
        {
            var departmentsIds = _context.DepartmentEmployees.Where(z => z.EmployeeId == employeeId).Select(z=> z.DepartmentId).ToList();
            return await _context.Departments.Where(z => departmentsIds.Contains(z.DepartmentId)).ToListAsync();
        }

        public void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.DepartmentEmployees.Remove(departmentEmployee);
            _context.SaveChanges();
        }
    }
}
