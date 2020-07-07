create procedure spGetPositions    
as    
begin     
select * from Position   
end
GO

create procedure spGetPositionById
@PositionId int   
as    
begin     
select * from Position  where PositionId=@PositionId   
end
GO

create procedure spAddNewPosition  
@Name nvarchar(50)
as    
begin    
    insert into Position(Name)   
    values(@Name)     
end   
GO

create procedure spUpdatePosition   
@PositionId int,
@Name nvarchar(50)
as    
begin    
    update Position     
    set Name=@Name
	where PositionId=@PositionId    
end    
GO 
  
create procedure spDeletePosition 
@PositionId int       
as    
begin    
    delete from Position where PositionId=@PositionId    
end     