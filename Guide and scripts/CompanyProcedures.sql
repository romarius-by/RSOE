create procedure spGetCompanies   
as    
begin     
select * from Company  
end
GO

create procedure spGetCompanyById
@CompanyId int   
as    
begin     
select * from Company  where CompanyId=@CompanyId   
end
GO

create procedure spAddNewCompany 
@Name nvarchar(50),
@Size nvarchar(50),  
@Form nvarchar(50)
as      
begin    
    insert into Company(Name, Size, Form)   
    values(@Name, @Size, @Form)     
end    
GO

create procedure spUpdateCompany   
@CompanyId int,
@Name nvarchar(50),
@Size nvarchar(50),  
@Form nvarchar(50) 
as    
begin    
    update Company     
    set Name=@Name, Size=@Size, Form=@Form
	where CompanyId=@CompanyId    
end    
GO 
  
create procedure spDeleteCompany
@CompanyId int       
as    
begin    
    delete from Company where CompanyId=@CompanyId    
end    