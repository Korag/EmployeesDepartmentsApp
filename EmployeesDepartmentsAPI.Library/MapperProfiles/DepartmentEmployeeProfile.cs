using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDepartmentsAPI.Library.MapperProfiles
{
    public class DepartmentEmployeeProfile : Profile
    {
        public DepartmentEmployeeProfile()
        {
            CreateMap<EmployeeModel, EmployeeDepartmentsDto>();
            CreateMap<DepartmentModel, DepartmentEmployeesDto>();
            CreateMap<DeleteDepartmentEmployeeDto, DepartmentEmployeesDto>();
            CreateMap<DeleteDepartmentEmployeeDto, DepartmentEmployeeModel>();
            CreateMap<CreateDepartmentEmployeeDto, DepartmentEmployeeModel>();
        }
    }
}
