using EmployeesDepartments.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId);
        Task<ICollection<EmployeeModel>> GetEmployeesGroupByIdsAsync(ICollection<int> employeesIds);
        Task<ICollection<EmployeeModel>> GetEmployeesAsync();

        Task<int> AddEmployeeAsync(EmployeeModel newEmployee);
        void RemoveEmployee(EmployeeModel employee);
        void UpdateEmployee(EmployeeModel updatedEmployee);
        bool CheckIfEmployeeExist(int employeeId);
    }
}
