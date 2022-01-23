using System.ComponentModel.DataAnnotations;

namespace EmployeesDepartments.DataAccess.Models
{
    public class DepartmentEmployeeModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [Key]
        public int DepartmentId { get; set; }
        public virtual DepartmentModel Department { get; set; }

        [Key]
        public int EmployeeId { get; set; }
        public virtual EmployeeModel Employee { get; set; }

        public DepartmentEmployeeModel()
        {

        }
    }
}
