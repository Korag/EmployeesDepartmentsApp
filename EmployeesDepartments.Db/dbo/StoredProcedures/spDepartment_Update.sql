CREATE PROCEDURE [dbo].[spDepartment_Update]
    @DepartmentId   INT,
	@Name    NVARCHAR (100)
AS
BEGIN
	UPDATE [dbo].[Departments]
	SET Name = @Name
    WHERE DepartmentId = @DepartmentId
END