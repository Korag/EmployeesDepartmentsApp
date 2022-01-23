using EmployeesDepartments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EFDbContext _context;

        public EFEmployeeRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddEmployeeAsync(EmployeeModel newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee.EmployeeId;
        }

        public bool CheckIfEmployeeExist(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            return employee == null ? false : true;
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<ICollection<EmployeeModel>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<ICollection<EmployeeModel>> GetEmployesGroupByIdsAsync(ICollection<int> employeesIds)
        {
            return await _context.Employees.Where(z => employeesIds.Contains(z.EmployeeId)).ToListAsync();
        }

        public void RemoveEmployee(EmployeeModel employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
        }
    }
}
