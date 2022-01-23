CREATE PROCEDURE [dbo].[spDepartmentEmployee_GetByDepartmentName]
	@DepartmentName NVARCHAR(100)
AS
BEGIN
SELECT e.EmployeeId, [FirstName], [LastName], [EmailAddress], [Age], [Role], [Sex] FROM [dbo].[Employees] e
	INNER JOIN [dbo].[DepartmentEmployees] de ON e.EmployeeId = de.EmployeeId
	INNER JOIN [dbo].[Departments] d ON d.DepartmentId = de.DepartmentId
	WHERE d.Name = @DepartmentName
END
