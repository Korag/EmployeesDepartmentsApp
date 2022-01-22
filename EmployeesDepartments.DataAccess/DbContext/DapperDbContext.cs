using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartments.DataAccess
{
    public class DapperDbContext
    {
        private IConfiguration _config;

        public DapperDbContext(IConfiguration config)
        {
            _config = config;
        }
    }
}
