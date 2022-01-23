CREATE PROCEDURE [dbo].[spDepartment_GetById]
	@DepartmentId int
AS
BEGIN
	SELECT [DepartmentId], [Name] FROM [dbo].[Departments] d
	WHERE d.DepartmentId = @DepartmentId
END