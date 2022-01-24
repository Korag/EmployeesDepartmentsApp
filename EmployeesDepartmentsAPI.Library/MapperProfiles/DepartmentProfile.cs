using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;

namespace EmployeesDepartmentsAPI.Library.MapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentModel, DepartmentDto>();
            CreateMap<UpdateDepartmentDto, DepartmentModel>();
            CreateMap<CreateDepartmentDto, DepartmentModel>();
        }
    }
}
