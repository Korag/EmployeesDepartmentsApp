CREATE PROCEDURE [dbo].[spEmployee_GetById]
	@EmployeeId int
AS
BEGIN
	SELECT [EmployeeId], [FirstName], [LastName], [EmailAddress], [Age], [Role], [Sex] FROM [dbo].[Employees] e
	WHERE e.EmployeeId = @EmployeeId
END