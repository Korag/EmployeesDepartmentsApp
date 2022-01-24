using EmployeesDepartments.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public interface IDepartmentEmployeeRepository
    {
        Task<ICollection<EmployeeModel>> GetEmployeesByDepartmentIdAsync(int departmentId);
        Task<ICollection<DepartmentModel>> GetEmployeesDepartmentsAsync(int employeeId);

        void AssignEmployeeToDepartment(DepartmentEmployeeModel departmentEmployee);
        void RemoveEmployeeFromDepartment(DepartmentEmployeeModel departmentEmployee);

        bool CheckIfUserBelongsToDepartment(int employeeId, int departmentId);
    }
}