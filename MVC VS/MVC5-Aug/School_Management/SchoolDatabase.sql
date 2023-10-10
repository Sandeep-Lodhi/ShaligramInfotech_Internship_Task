create database Ram_School_Management_352
use Ram_School_Management_352

create table [User](
UserId int Primary key identity(1,1),
FirstName varchar(255) not null,
LastName varchar(255) not null,
Email varchar(255) unique,
[Password] varchar(25) not null,
RoleId int not null 
)
select * from [User]

create table Country(
CountryId int Primary key identity(1 ,1),
CountryName varchar(255)
)
select * from Country

create table [State](
StateId int Primary key identity(1 ,1),
StateName varchar(255),
CountryId int foreign key references Country(CountryId)
)
select * from [State]


create table City(
CityId int Primary key identity(1 ,1),
CityName varchar(255),
StateId int foreign key references [State](StateId),
CountryId int foreign key references Country(CountryId)
)

select * from City

--State_addedit
create or alter proc sp_stateadd_edit
@StateId int,
@StateName varchar(255),
@CountryId int
as
begin 
if(@StateId is null or  @StateId=0)
	begin
		insert into [State]
		values(@StateName,@CountryId)
	end
else
	begin
		begin tran
			update [State]
			set  StateName =@StateName,CountryId=@CountryId
			where StateId=@StateId
		commit tran
	end
end

exec sp_stateadd_edit 1,'Punjab2',3

select *from state


--show state
create or alter PROC StateList
AS
BEGIN
	SELECT S.*,C.CountryName FROM STATE S INNER JOIN Country C on S.CountryId = C.CountryId
END

exec StateList

--cityaddedit
create or alter proc sp_cityadd_edit
@CityId int,
@CityName varchar(255),
@StateId int,
@CountryId int

as
begin 
if(@CityId is null or  @CityId=0)
	begin
		insert into City
		values(@CityName,@StateId,@CountryId)
	end
else
	begin
		begin tran
			update City
			set  CityName =@CityName,StateId=@StateId,CountryId=@CountryId
			where CityId=@CityId
		commit tran
	end
end

exec sp_cityadd_edit 0,'Rajkot220',1,1

--showcity

CREATE PROC CityList
AS
BEGIN
	SELECT CT.*, C.CountryName, s.StateName FROM City CT 
	inner join	State S on CT.StateId = S.StateId
	inner join Country C on  CT.CountryId=C.CountryId
END

exec CityList


----citydelete

--create proc deletecity
--@CityId int
--as
--begin
--	delete from City
--	where CityId=@CityId
--end
