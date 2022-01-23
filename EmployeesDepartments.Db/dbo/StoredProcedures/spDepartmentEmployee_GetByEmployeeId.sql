CREATE PROCEDURE [dbo].[spDepartmentEmployee_GetByEmployeeId]
	@EmployeeId INT
AS
BEGIN
SELECT d.DepartmentId, [Name] FROM [dbo].[Departments] d
	INNER JOIN [dbo].[DepartmentEmployees] de ON d.DepartmentId = de.DepartmentId
    INNER JOIN [dbo].[Employees] e ON e.EmployeeId = de.EmployeeId
	WHERE e.EmployeeId = @EmployeeId
END