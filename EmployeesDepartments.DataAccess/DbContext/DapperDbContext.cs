using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess
{
    public class DapperDbContext : IDapperDbContext
    {
        private IConfiguration _config;

        public DapperDbContext(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedureName,
            U parameters,
            string connectionStringName = "Default")
        {
            using (IDbConnection conn = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                return await conn.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task SaveData<T>(
         string storedProcedureName,
         T parameters,
         string connectionStringName = "Default")
        {
            using (IDbConnection conn = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                await conn.ExecuteAsync(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> SaveDataGetId<T>(
         string storedProcedureName,
         T parameters,
         string connectionStringName = "Default")
        {
            using (IDbConnection conn = new SqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                return await conn.QuerySingleAsync<int>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
