using AutoMapper;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartments.DataAccess.Repositories;
using EmployeesDepartmentsAPI.Controllers;
using EmployeesDepartmentsAPI.Library.DataTransferObjects;
using EmployeesDepartmentsAPI.Library.MapperProfiles;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace EmployeesDepartmentsAPI.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        public EmployeeControllerTests()
        {

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(null)]
        public void GetEmployeeById_IfValidId_ReturnNotEmptyEmployeeData(int id)
        {
            //Arrange
            var mockedEmployeeId = 1;

            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            mockEmployeeRepo.Setup(z => z.GetEmployeeByIdAsync(1))
                .ReturnsAsync(new EmployeeModel() 
                {
                    EmployeeId = mockedEmployeeId,
                    FirstName = "Test",
                    LastName = "Test",
                    EmailAddress = "test@test.com",
                    Age = 1,
                    Role = "manager",
                    Sex = 'M'
                });

            //Auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EmployeeProfiles());
            });
            var mapper = mockMapper.CreateMapper();

            var employeeController = new EmployeeController(mockEmployeeRepo.Object, mapper);

            //Act
            var result = employeeController.GetEmployee(id).Result;

            //Assert
            if (id == mockedEmployeeId)
            {
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                Assert.IsType<EmployeeDto>(okResult.Value);
                Assert.NotNull(okResult.Value);
            }
            else
            {
                var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}


//ADD REPO TEST
//ADD CLASS TEST