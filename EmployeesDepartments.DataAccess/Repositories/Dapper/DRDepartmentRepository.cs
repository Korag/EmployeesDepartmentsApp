using EmployeesDepartments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DRDepartmentRepository : IDepartmentRepository
    {
        public DRDepartmentRepository()
        {
                
        }

        public Task<int> AddDepartmentAsync(DepartmentModel newDepartment)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfDepartmentExist(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentModel> GetDepartmentByIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentModel>> GetDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DepartmentModel>> GetDepartmentsGroupByIdsAsync(ICollection<int> departmentsIds)
        {
            throw new NotImplementedException();
        }

        public void RemoveDepartment(DepartmentModel department)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(DepartmentModel updatedDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
