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
            _context.SaveData("dbo.spDepartmentEmployee_Insert", new { employeeId = departmentEmployee.EmployeeId, departmentId = departmentEmployee.DepartmentId });
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

        public async Task<ICollection<EmployeeModel>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var results = await _context.LoadData<EmployeeModel, dynamic>("dbo.spDepartmentEmployee_GetByDepartmentId", new { departmentId = departmentId });
            return results.ToList();
        }

        public async Task<ICollection<DepartmentModel>> GetEmployeesDepartmentsAsync(int employeeId)
        {
            var results = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartmentEmployee_GetByEmployeeId", new { employeeId = employeeId });
            return results.ToList();
        }

        public void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            _context.SaveData("dbo.spDepartmentEmployee_Delete", new { employeeId = departmentEmployee.EmployeeId, departmentId = departmentEmployee.DepartmentId });
        }
    }
}
