create procedure spGetEmployees    
as    
begin     
select * from Employee    
end
GO

create procedure spGetEmployeeById
(
@EmployeeId int
)
as    
begin    
	select * from Employee  where EmployeeId=@EmployeeId    
end
GO

create procedure spAddNewEmployee   
@FirstName nvarchar(50),
@LastName nvarchar(50),  
@EmploymentDate date, 
@CompanyId int, 
@PositionId int
as    
begin    
    insert into Employee(FirstName, LastName, EmploymentDate, PositionId, CompanyId)    
    values(@FirstName, @LastName, @EmploymentDate, @PositionId, @CompanyId)    
end
GO

create procedure spUpdateEmployee    
@EmployeeId int, 
@FirstName nvarchar(50),
@LastName nvarchar(50),  
@EmploymentDate date,  
@PositionId int,  
@CompanyId int     
as    
begin    
    update Employee     
    set FirstName=@FirstName, LastName=@LastName, EmploymentDate=@EmploymentDate,  
	CompanyId=@CompanyId, PositionId=@PositionId
	where EmployeeId=@EmployeeId    
end
GO

create procedure spDeleteEmployee    
(    
@EmployeeId int    
)    
as    
begin    
    delete from Employee where EmployeeId=@EmployeeId    
end    