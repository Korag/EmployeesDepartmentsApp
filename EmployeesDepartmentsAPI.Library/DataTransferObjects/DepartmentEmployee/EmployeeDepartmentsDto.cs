using System.Collections.Generic;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class EmployeeDepartmentsDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public char Sex { get; set; }

        public ICollection<DepartmentDto> Departments { get; set; }

        public EmployeeDepartmentsDto()
        {

        }
    }
}
