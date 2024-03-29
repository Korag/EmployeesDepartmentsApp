﻿using EmployeesDepartments.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DREmployeeRepository : IEmployeeRepository
    {
        private IDapperDbContext _context;

        public DREmployeeRepository(IDapperDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(EmployeeModel newEmployee)
        {
            return await _context.SaveDataGetId("dbo.spEmployee_Insert", new { firstName = newEmployee.FirstName, lastName = newEmployee.LastName, emailAddress = newEmployee.EmailAddress, age = newEmployee.Age, role = newEmployee.Role, sex = newEmployee.Sex  });
        }

        public bool CheckIfEmployeeExist(int employeeId)
        {
            if (GetEmployeeByIdAsync(employeeId).Result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            var results = await _context.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_GetById", new { employeeId = employeeId });
            return results.ToList().FirstOrDefault();
        }

        public async Task<ICollection<EmployeeModel>> GetEmployeesAsync()
        {
            var results = await _context.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_Get", new { });
            return results.ToList();
        }

        public async Task<ICollection<EmployeeModel>> GetEmployeesGroupByIdsAsync(ICollection<int> employeesIds)
        {
            List<EmployeeModel> results = new List<EmployeeModel>();

            foreach (var employeeId in employeesIds)
            {
                var result = await _context.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_Get", new { employeeId = employeeId });
                var employee = result.ToList().FirstOrDefault();

                if (employee != null)
                {
                    results.Add(employee);
                }
            }

            return results;
        }

        public void RemoveEmployee(EmployeeModel employee)
        {
            _context.SaveData("dbo.spEmployee_Delete", new { employeeId = employee.EmployeeId });
        }

        public void UpdateEmployee(EmployeeModel updatedEmployee)
        {
            _context.SaveData("dbo.spEmployee_Update", new { employeeId = updatedEmployee.EmployeeId, firstName = updatedEmployee.FirstName, lastName = updatedEmployee.LastName, emailAddress = updatedEmployee.EmailAddress, age = updatedEmployee.Age, role = updatedEmployee.Role, sex = updatedEmployee.Sex });
        }
    }
}
