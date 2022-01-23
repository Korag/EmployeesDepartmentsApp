CREATE PROCEDURE [dbo].[spEmployee_Update]
    @EmployeeId   INT,
	@FirstName    NVARCHAR (100),
    @LastName     NVARCHAR (100),
    @EmailAddress NVARCHAR (30),
    @Age          INT,
    @Role         NVARCHAR (30),
    @Sex          NVARCHAR (1)
AS
BEGIN
	UPDATE [dbo].[Employees]
	SET FirstName = @FirstName,
    LastName = @LastName,
    EmailAddress = @EmailAddress,
    Age = @Age,
    Role = @Role,
    Sex = @Sex
    WHERE EmployeeId = @EmployeeId
END