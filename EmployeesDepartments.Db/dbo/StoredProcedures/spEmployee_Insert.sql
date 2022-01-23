CREATE PROCEDURE [dbo].[spEmployee_Insert]
	@FirstName    NVARCHAR (100),
    @LastName     NVARCHAR (100),
    @EmailAddress NVARCHAR (30),
    @Age          INT,
    @Role         NVARCHAR (30),
    @Sex          NVARCHAR (1)
AS
BEGIN
	INSERT INTO [dbo].[Employees] (FirstName, LastName, EmailAddress, Age, Role, Sex)
    VALUES (@FirstName, @LastName, @EmailAddress, @Age, @Role, @Sex)
END