using System.ComponentModel.DataAnnotations;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class DeleteDepartmentEmployeeDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public DeleteDepartmentEmployeeDto()
        {

        }
    }
}
