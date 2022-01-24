using System.ComponentModel.DataAnnotations;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class UpdateDepartmentDto
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public UpdateDepartmentDto()
        {

        }
    }
}
