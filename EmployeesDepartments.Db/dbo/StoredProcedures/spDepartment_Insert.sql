CREATE PROCEDURE [dbo].[spDepartment_Insert]
    @Name NVARCHAR (100)
AS
BEGIN
	INSERT INTO [dbo].[Departments] (Name)
	VALUES (@Name)
END
