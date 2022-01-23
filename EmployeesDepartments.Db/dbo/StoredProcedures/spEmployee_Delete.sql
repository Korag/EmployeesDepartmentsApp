CREATE PROCEDURE [dbo].[spEmployee_Delete]
	@EmployeeId int
AS
BEGIN
	DELETE FROM [dbo].[Employees]
	WHERE [dbo].[Employees].EmployeeId = @EmployeeId
END
