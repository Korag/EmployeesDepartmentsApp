using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesDepartments.DataAccess.Models
{
    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Range(16, 99)]
        public int Age { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string Role { get; set; }

        [Required]
        [StringLength(1)]
        [DataType(DataType.Text)]
        public char Sex { get; set; }

        public virtual ICollection<DepartmentEmployeeModel> DepartmentEmployees { get; set; }

        public EmployeeModel()
        {

        }
    }
}
