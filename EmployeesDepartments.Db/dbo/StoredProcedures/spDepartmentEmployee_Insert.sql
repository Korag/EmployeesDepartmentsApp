CREATE PROCEDURE [dbo].[spDepartmentEmployee_Insert]
	@EmployeeId INT,
	@DepartmentId INT
AS
BEGIN
	INSERT INTO [dbo].[DepartmentEmployees] (EmployeeId, DepartmentId)
	VALUES (@EmployeeId, @DepartmentId)
END
