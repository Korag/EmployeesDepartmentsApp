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
            return await _context.SaveDataGetId<DepartmentModel>("dbo.spDepartment_Insert", newDepartment);
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
            var results = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartment_GetById", new { id = departmentId });
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
                var result = await _context.LoadData<DepartmentModel, dynamic>("dbo.spDepartment_Get", new { Id = departmentId });
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
            _context.SaveData("dbo.spDepartment_Remove", new { Id = department.DepartmentId });
        }

        public void UpdateDepartment(DepartmentModel updatedDepartment)
        {
            _context.SaveData<DepartmentModel>("dbo.spDepartment_Update", updatedDepartment);
        }
    }
}
