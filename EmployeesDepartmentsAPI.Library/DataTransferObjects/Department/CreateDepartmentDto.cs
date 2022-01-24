using System.ComponentModel.DataAnnotations;

namespace EmployeesDepartmentsAPI.Library.DataTransferObjects
{
    public class CreateDepartmentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public CreateDepartmentDto()
        {

        }
    }
}
