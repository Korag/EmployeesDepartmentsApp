using EmployeesDepartments.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess.Repositories
{
    public class DRDepartmentRepository : IDepartmentRepository
    {
        private IDapperDbContext _context;

        public DRDepartmentRepository(IDapperDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddDepartmentAsync(DepartmentModel newDepartment)
        {
            return await _context.SaveDataGetId("dbo.spDepartment_Insert", new { name = newDepartment.Name });
        }

        public bool CheckIfDepartmentExist(int departmentId)
        {
            if (GetDepartmentByIdAsync(departmentId).Result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int departmentId)
        {
            var results = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartment_GetById", new { departmentId = departmentId });
            return results.ToList().FirstOrDefault();
        }

        public async Task<ICollection<DepartmentModel>> GetDepartmentsAsync()
        {
            var results = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartment_Get", new { });
            return results.ToList();
        }

        public async Task<ICollection<DepartmentModel>> GetDepartmentsGroupByIdsAsync(ICollection<int> departmentsIds)
        {
            List<DepartmentModel> results = new List<DepartmentModel>();

            foreach (var departmentId in departmentsIds)
            {
                var result = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartment_Get", new { departmentId = departmentId });
                var department = result.ToList().FirstOrDefault();

                if (department != null)
                {
                    results.Add(department);
                }
            }

            return results;
        }

        public void RemoveDepartment(DepartmentModel department)
        {
            _context.SaveData("dbo.spDepartment_Delete", new { departmentId = department.DepartmentId });
        }

        public void UpdateDepartment(DepartmentModel updatedDepartment)
        {
            _context.SaveData("dbo.spDepartment_Update", new { departmentId = updatedDepartment.DepartmentId, name = updatedDepartment.Name } );
        }
    }
}
