CREATE PROCEDURE [dbo].[spDepartmentEmployee_Delete]
	@EmployeeId INT,
	@DepartmentId INT
AS
BEGIN
	DELETE FROM [dbo].[DepartmentEmployees]
	WHERE EmployeeId = @EmployeeId AND DepartmentId = @DepartmentId
END