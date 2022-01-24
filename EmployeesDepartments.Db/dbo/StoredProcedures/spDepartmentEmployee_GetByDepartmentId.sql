CREATE PROCEDURE [dbo].[spDepartmentEmployee_GetByDepartmentId]
	@DepartmentId INT
AS
BEGIN
SELECT e.EmployeeId, [FirstName], [LastName], [EmailAddress], [Age], [Role], [Sex] FROM [dbo].[Employees] e
	INNER JOIN [dbo].[DepartmentEmployees] de ON e.EmployeeId = de.EmployeeId
	INNER JOIN [dbo].[Departments] d ON d.DepartmentId = de.DepartmentId
	WHERE d.DepartmentId = @DepartmentId
END
