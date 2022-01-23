CREATE PROCEDURE [dbo].[spDepartment_Delete]
	@DepartmentId INT
AS
BEGIN
	DELETE FROM [dbo].[Departments]
	WHERE [dbo].[Departments].DepartmentId = @DepartmentId
END
