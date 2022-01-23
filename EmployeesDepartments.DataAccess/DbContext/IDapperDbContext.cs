using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess
{
    public interface IDapperDbContext
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedureName, U parameters, string connectionStringName = "Default");
        Task SaveData<T>(string storedProcedureName, T parameters, string connectionStringName = "Default");
        Task<int> SaveDataGetId<T>(string storedProcedureName, T parameters, string connectionStringName = "Default");
    }
}