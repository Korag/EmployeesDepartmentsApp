using System.Collections.Generic;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class DepartmentEmployeesDto
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }

        public DepartmentEmployeesDto()
        {

        }
    }
}
