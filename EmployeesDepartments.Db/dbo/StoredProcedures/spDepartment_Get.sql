CREATE PROCEDURE [dbo].[spDepartment_Get]
AS
BEGIN
	SELECT [DepartmentId], [Name] FROM [dbo].[Departments]
END