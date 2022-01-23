using EmployeesDepartments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DRDepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        private IDapperDbContext _context;

        public DRDepartmentEmployeeRepository(IDapperDbContext context)
        {
            _context = context;
        }

        public void AssignEmployeeToDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.SaveData<DepartmentEmployeeModel>("dbo.spDepartmentEmployee_Insert", departmentEmployee);
        }

        public bool CheckIfUserBelongsToDepartment(int employeeId, int departmentId)
        {
            var employeeDepartments = GetEmployeesDepartmentsAsync(employeeId).Result.ToList().Select(z => z.DepartmentId);

            if (employeeDepartments.Contains(departmentId))
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
            var results = await _context.LoadData<EmployeeModel, dynamic>("dbo.spDepartmentEmployee_GetByDepartmentName", new { name = departmentName });
            return results.ToList();
        }

        public async Task<ICollection<DepartmentModel>> GetEmployeesDepartmentsAsync(int employeeId)
        {
            var results = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartmentEmployee_GetByEmployeeId", new { id = employeeId });
            return results.ToList();
        }

        public void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.SaveData<DepartmentEmployeeModel>("dbo.spDepartmentEmployee_Delete", departmentEmployee);
        }
    }
}
