USE [RSOEDB]
GO
EXEC	[dbo].[spAddNewCompany]
		@Name = N'Qutix', @Size=N'Big', @Form=N'OOO'
GO

USE [RSOEDB]
GO
EXEC	[dbo].[spAddNewEmployee]
		@FirstName = N'Roman', @LastName = N'Litvin', @EmploymentDate = '2020/07/15', @PositionId = 1, @CompanyId = 1
GO
