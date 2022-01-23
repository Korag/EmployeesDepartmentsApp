using EmployeesDepartments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DRDepartmentEmployeeRepository : IDepartmentEmployeeRepository
    {
        public DRDepartmentEmployeeRepository()
        {
                
        }

        public void AssignEmployeeToDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfUserBelongsToDepartment(int employeeId, int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EmployeeModel>> GetEmployeesByDepartmentNameAsync(string departmentName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentModel>> GetEmployeesDepartmentsAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
