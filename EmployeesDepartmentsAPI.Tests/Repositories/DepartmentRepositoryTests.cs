using AutoFixture;
using EmployeesDepartments.DataAccess;
using EmployeesDepartments.DataAccess.Models;
using EmployeesDepartments.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesDepartmentsAPI.Tests.Repositories
{
    public class DepartmentRepositoryTests
    {
        public DepartmentRepositoryTests()
        {

        }

        [Fact]
        public void CheckIfDepartmentExist_IfTrue_ReturnTrue()
        {
            var checkedDepartmentId = 1;

            //mockEFDbContext.Setup(z => z.Departments.Find(checkedDepartmentId)).Returns(new DepartmentModel() { DepartmentId = checkedDepartmentId, Name = "Test" });

            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var expectedDepartment = fixture.Build<DepartmentModel>().With(z => z.DepartmentId, checkedDepartmentId).Create();
            var departments = new List<DepartmentModel>
                              {
                                expectedDepartment,
                                fixture.Build<DepartmentModel>().With(u => u.DepartmentId, 2).Create(),
                                fixture.Build<DepartmentModel>().With(u => u.DepartmentId, 3).Create()
                              }.AsQueryable();

            var departmentsMock = new Mock<DbSet<DepartmentModel>>();
            departmentsMock.As<IQueryable<DepartmentModel>>().Setup(m => m.Provider).Returns(departments.Provider);
            departmentsMock.As<IQueryable<DepartmentModel>>().Setup(m => m.Expression).Returns(departments.Expression);
            departmentsMock.As<IQueryable<DepartmentModel>>().Setup(m => m.ElementType).Returns(departments.ElementType);
            departmentsMock.As<IQueryable<DepartmentModel>>().Setup(m => m.GetEnumerator()).Returns(departments.GetEnumerator());

            var mockEFDbContext = new Mock<EFDbContext>();
            mockEFDbContext.Setup(x => x.Departments).Returns(departmentsMock.Object);

            EFDepartmentRepository repo = new EFDepartmentRepository(mockEFDbContext.Object);
            var result = repo.CheckIfDepartmentExist(checkedDepartmentId);

            Assert.True(result);
        }
    }
}
