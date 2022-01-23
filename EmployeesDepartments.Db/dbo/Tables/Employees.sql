CREATE TABLE [dbo].[Employees] (
    [EmployeeId]   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (100) NOT NULL,
    [LastName]     NVARCHAR (100) NOT NULL,
    [EmailAddress] NVARCHAR (30)  NOT NULL,
    [Age]          INT            NOT NULL,
    [Role]         NVARCHAR (30)  NOT NULL,
    [Sex]          NVARCHAR (1)   NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

