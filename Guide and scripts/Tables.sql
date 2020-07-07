CREATE TABLE [dbo].[Company](    
    [CompanyId] [int] IDENTITY(1,1) NOT NULL,    
    [Name] [nvarchar](50) NULL,
    [Size] [nvarchar](50) NULL,
    [Form] [nvarchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED     
(    
    [CompanyId] ASC    
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
) ON [PRIMARY]   
GO

CREATE TABLE [dbo].[Position](    
    [PositionId] [int] IDENTITY(1,1) NOT NULL,    
    [Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED     
(    
    [PositionId] ASC    
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
) ON [PRIMARY] 
GO

CREATE TABLE [dbo].[Employee](    
    [EmployeeId] [int] IDENTITY(1,1) NOT NULL,    
    [FirstName] [nvarchar](50) NULL,
    [LastName] [nvarchar](50) NULL,     
    [EmploymentDate] [date] NULL,  
    [PositionId] [int] NULL,  
    [CompanyId] [int] NULL,   
    FOREIGN KEY [PositionId] REFERENCES [dbo].[Position]([PositionId]),
    FOREIGN KEY [CompanyId] REFERENCES [dbo].[Company]([CompanyId]),  
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED     
(    
    [EmployeeId] ASC    
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]    
) ON [PRIMARY] 
GO 