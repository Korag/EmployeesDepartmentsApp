CREATE TABLE [dbo].[DepartmentEmployees] (
    [DepartmentId] INT NOT NULL,
    [EmployeeId]   INT NOT NULL,
    CONSTRAINT [PK_DepartmentEmployees] PRIMARY KEY CLUSTERED ([DepartmentId] ASC, [EmployeeId] ASC),
    CONSTRAINT [FK_DepartmentEmployees_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]) ON DELETE CASCADE,
    CONSTRAINT [FK_DepartmentEmployees_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([EmployeeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentEmployees_EmployeeId]
    ON [dbo].[DepartmentEmployees]([EmployeeId] ASC);

