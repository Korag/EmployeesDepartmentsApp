using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;

namespace EmployeesDepartmentsAPI.Library.MapperProfiles
{
    public class EmployeeProfiles : Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<EmployeeModel, EmployeeDto>();
            CreateMap<UpdateEmployeeDto, EmployeeModel>();
            CreateMap<CreateEmployeeDto, EmployeeModel>();
        }
    }
}
