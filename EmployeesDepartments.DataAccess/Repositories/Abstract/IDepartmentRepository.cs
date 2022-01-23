using EmployeesDepartments.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public interface IDepartmentRepository
    {
        Task<DepartmentModel> GetDepartmentByIdAsync(int departmentId);
        Task<ICollection<DepartmentModel>> GetDepartmentsGroupByIdsAsync(ICollection<int> departmentsIds);
        Task<ICollection<DepartmentModel>> GetDepartmentsAsync();

        Task<int> AddDepartmentAsync(DepartmentModel newDepartment);
        void RemoveDepartment(DepartmentModel department);
        void UpdateDepartment(DepartmentModel updatedDepartment);
        bool CheckIfDepartmentExist(int departmentId);
    }
}
