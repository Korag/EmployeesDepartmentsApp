using EmployeesDepartments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DREmployeeRepository : IEmployeeRepository
    {
        public DREmployeeRepository()
        {
                
        }

        public Task<int> AddEmployeeAsync(EmployeeModel newEmployee)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfEmployeeExist(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EmployeeModel>> GetEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EmployeeModel>> GetEmployesGroupByIdsAsync(ICollection<int> employeesIds)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(EmployeeModel employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(EmployeeModel updatedEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
