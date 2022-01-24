using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class CreateDepartmentEmployeeDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public CreateDepartmentEmployeeDto()
        {

        }
    }
}
