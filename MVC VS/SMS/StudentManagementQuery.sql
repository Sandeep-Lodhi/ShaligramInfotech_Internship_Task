--create database SP355SanjayPrajapati
--go

--use SP355SanjayPrajapati
--go

create table [User](
	UserId int primary key identity(1,1),
	UserFirstName varchar(250),
	UserLastName varchar(250),
	UserName varchar(250) unique,
	UserEmail varchar(250) unique,
	UserPassWord varchar(250),
)


create table Role(
	RoleId int primary key identity(1,1),
	RoleName varchar(250) unique
)


create table UserRole(
	UserRoleId int primary key identity(1,1),
	UserId int foreign key references [User](UserId),
	RoleId int foreign key references [Role](RoleId),
)


create table Standard(
	StandardId int primary key identity(1,1),
	StandardName varchar(250) unique
)



create table Country(
	CountryId int primary key identity(1,1),
	CountryName varchar(255),
)

create table State(
	StateId int primary key identity(1,1),
	StateName varchar(255),
	CountryId int foreign key references Country(CountryId)
)

create table City(
	CityId int primary key identity(1,1),
	CityName varchar(255),
	StateId int foreign key references State(StateId),
	CountryId int foreign key references Country(CountryId)
)

create table Student(
	StudentId int primary key identity(1,1),
	StudentFirstName varchar(255),
	StudentLastName varchar(255),
	StudentAddress varchar(max),
	StudentMobileNo varchar(50),
	StudentEmail varchar(250),
	StudentGenderName varchar(255),
	StudentDOB date,
	StudentStandardId int foreign key references Standard(StandardId),
	StudentCountryId int foreign key references Country(CountryId),
	StudentStateId int foreign key references State(StateId),
	StudentCityId int foreign key references City(CityId),
)


create table Teacher(
	TeacherId int primary key identity(1,1),
	TeacherFirstName varchar(255),
	TeacherLastName varchar(255),
	TeacherAddress varchar(max),
	TeacherMobileNo varchar(50),
	TeacherEmail varchar(250),
	TeacherGenderName varchar(255),
	TeacherDOB date,
	TeacherCountryId int foreign key references Country(CountryId),
	TeacherStateId int foreign key references State(StateId),
	TeacherCityId int foreign key references City(CityId),
)


create table Subject(
	SubjectId int primary key identity(1,1),
	SubjectName varchar(255)
)

create table StudentTeacher(
	StudentTeacherId int primary key identity(1,1),
	StudentId int foreign key references Student(StudentId),
	TeacherId int foreign key references Teacher(TeacherId),
)

create table StudentSubject(
	StudentSubjectId int primary key identity(1,1),
	StudentId int foreign key references Student(StudentId),
	SubjectId int foreign key references Subject(SubjectId)
)

create table TeacherSubject(
	TeacherSubjectId int primary key identity(1,1),
	TeacherId int foreign key references Teacher(TeacherId),
	SubjectId int foreign key references Subject(SubjectId)
)

--drop table UserRole
--drop table StudentTeacher
--drop table StudentSubject
--drop table TeacherSubject











go

create or alter proc Sp_AddEditUser
(
	@UserId int = null,
	@UserFirstName varchar(250),
	@UserLastName varchar(250),
	@UserName varchar(250),
	@UserEmail varchar(250),
	@UserPassWord varchar(250)
)
as
begin
	if(@UserId is null)
		begin
			begin try
				begin tran
					insert into [User]
					values(@UserFirstName,@UserLastName, @UserName,@UserEmail,@UserPassWord)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update [User]
					set
						UserFirstName=@UserFirstName,
						UserLastName=@UserLastName, 
						UserName=@UserName,
						UserEmail=@UserEmail,
						UserPassWord=@UserPassWord
					where UserId=@UserId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go


select * from [User]

exec Sp_AddEditUser null,'Sanjay','Prajapati','sanju8490','svprajapati812@gmail.com','123456'
exec Sp_AddEditUser null,'Jigar','Prajapati','Jigar123','jigar@gmail.com','123456'
exec Sp_AddEditUser null,'Jay','Patel','jay123','jay@gmail.com','123456'
exec Sp_AddEditUser null,'Chirag','Patel','chirag123','chirag@gmail.com','123456'
exec Sp_AddEditUser null,'Ateet','Prajapati','ateet123','ateet@gmail.com','123456'











go

create or alter proc Sp_AddEditRole
(
	@RoleId int = null,
	@RoleName varchar(250)
)
as
begin
	if(@RoleId is null)
		begin
			begin try
				begin tran
					insert into Role
					values(@RoleName)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Role
					set
						RoleName=@RoleName
					where RoleId=@RoleId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go

select * from Role

exec Sp_AddEditRole null,'Admin'
exec Sp_AddEditRole null,'Student'
exec Sp_AddEditRole null,'Teacher'

go











create or alter proc Sp_AddDeleteUserRole
(
	@action varchar(250),
	@UserId int,
	@RoleId int
)
as
begin
	if (@action='add')
		begin
			begin try
				begin tran
					insert into UserRole
					values(@UserId,@RoleId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					delete from UserRole
					where UserId=@UserId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go

select * from [user]
select * from Role
select * from UserRole

exec Sp_AddDeleteUserRole 'add',1,1
exec Sp_AddDeleteUserRole 'add',1,2
exec Sp_AddDeleteUserRole 'add',2,3
exec Sp_AddDeleteUserRole 'add',3,3
exec Sp_AddDeleteUserRole 'add',4,2
exec Sp_AddDeleteUserRole 'add',5,2










go


create or alter proc Sp_AddEditStandard
(
	@StandardId int = null,
	@StandardName varchar(250)
)
as
begin
	if(@StandardId is null)
		begin
			begin try
				begin tran
					insert into Standard
					values(@StandardName)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Standard
					set
						StandardName=@StandardName
					where StandardId=@StandardId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go

select * from Standard order by StandardId


exec Sp_AddEditStandard null,'Standard-9'
exec Sp_AddEditStandard null,'Standard-10'
exec Sp_AddEditStandard null,'Standard-11'
exec Sp_AddEditStandard null,'Standard-12'








go
create or alter proc Sp_AddEditCountry
(
	@CountryId int = null,
	@CountryName varchar(250)
)
as
begin
	if(@CountryId is null)
		begin
			begin try
				begin tran
					insert into Country
					values(@CountryName)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Country
					set
						CountryName=@CountryName
					where CountryId=@CountryId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go
select * from Country

exec Sp_AddEditCountry null,'India'
exec Sp_AddEditCountry null,'Pakistan'
exec Sp_AddEditCountry null,'Chaina'
exec Sp_AddEditCountry null,'USA'
exec Sp_AddEditCountry null,'England'
exec Sp_AddEditCountry null,'Japan'







go

create or alter proc Sp_AddEditState
(
	@StateId int = null,
	@StateName varchar(250),
	@CountryId int
)
as
begin
	if(@StateId is null)
		begin
			begin try
				begin tran
					insert into State
					values(@StateName,@CountryId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update State
					set
						StateName=@StateName,
						CountryId=@CountryId
					where StateId=@StateId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end
go


select * from Country
select * from State

exec Sp_AddEditState null,'Gujarat',1
exec Sp_AddEditState null,'Rajasthan',1
exec Sp_AddEditState null,'Maharastra',1
exec Sp_AddEditState null,'NewYork',4
exec Sp_AddEditState null,'Beijing',3
exec Sp_AddEditState null,'Shikoku',6









go

create or alter proc Sp_AddEditCity
(
	@CityId int = null,
	@CityName varchar(250),
	@CountryId int,
	@StateId int
)
as
begin
	if(@CityId is null)
		begin
			begin try
				begin tran
					insert into City
					values(@CityName,@CountryId,@StateId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update City
					set
						CityName=@CityName,
						CountryId=@CountryId,
						StateId=@StateId
					where CityId=@CityId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end
go
 
 select * from Country
 select * from State
 select * from City

exec Sp_AddEditCity null,'Ahmedabad',1,1
exec Sp_AddEditCity null,'Mehsana',1,1
exec Sp_AddEditCity null,'Jaipur',1,2
exec Sp_AddEditCity null,'NewYork City',4,4
exec Sp_AddEditCity null,'Tokyo',6,6
exec Sp_AddEditCity null,'Beijing City',3,5












go
create or alter proc Sp_AddEditStudent
(
	@StudentId int =null,
	@StudentFirstName varchar(255),
	@StudentLastName varchar(255),
	@StudentAddress varchar(max),
	@StudentMobileNo varchar(50),
	@StudentEmail varchar(250),
	@StudentGenderName varchar(255),
	@StudentDOB date,
	@StudentStandardId int,
	@StudentCountryId int,
	@StudentStateId int,
	@StudentCityId int
)
as
begin
	if(@StudentId is null)
		begin
			begin try
				begin tran
					insert into Student
					values(
						   @StudentFirstName,
						   @StudentLastName,
						   @StudentAddress,
						   @StudentMobileNo,
						   @StudentEmail,
						   @StudentGenderName,
						   @StudentDOB,
						   @StudentStandardId,
						   @StudentCountryId,
						   @StudentStateId,
						   @StudentCityId
						   )
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Student
					set
						StudentFirstName=@StudentFirstName,
						StudentLastName=@StudentLastName,
						StudentAddress=@StudentAddress,
						StudentMobileNo=@StudentMobileNo,
						StudentEmail=@StudentEmail,
						StudentGenderName	=@StudentGenderName,
						StudentDOB	=@StudentDOB,
						StudentStandardId=@StudentStandardId,
						StudentCountryId=@StudentCountryId,
						StudentStateId=@StudentStateId,
						StudentCityId=@StudentCityId
					where StudentId=@StudentId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go

select * from Standard
select * from Country
select * from State
select * from  city

exec Sp_AddEditStudent null,'Sanjay','Prajapati','Prajapati vas Vav','8490880089','svprajapati812@gmail.com','Male','2001-10-28','4','1','1','2'
exec Sp_AddEditStudent null,'Tilak','Purani','Udaipur vas Udaipur','5688745788','tilak@@gmail.com','Male','2002-01-17','3','1','2','3'

select * from Student s
inner join City c on s.StudentCityId=c.CityId

go













create or alter proc Sp_AddEditTeacher
(
	@TeacherId int = null,
	@TeacherFirstName varchar(255),
	@TeacherLastName varchar(255),
	@TeacherAddress varchar(max),
	@TeacherMobileNo varchar(50),
	@TeacherEmail varchar(250),
	@TeacherGenderName varchar(255),
	@TeacherDOB date,
	@TeacherCountryId int,
	@TeacherStateId int,
	@TeacherCityId int
)
as
begin
	if(@TeacherId is null)
		begin
			begin try
				begin tran
					insert into Teacher
					values(
						   @TeacherFirstName,
						   @TeacherLastName,
						   @TeacherAddress,
						   @TeacherMobileNo,
						   @TeacherEmail,
						   @TeacherGenderName,
						   @TeacherDOB,
						   @TeacherCountryId,
						   @TeacherStateId,
						   @TeacherCityId
						   )
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Teacher
					set
						TeacherFirstName=@TeacherFirstName,
						TeacherLastName=@TeacherLastName,
						TeacherAddress=	@TeacherAddress,
						TeacherMobileNo=@TeacherMobileNo,
						TeacherEmail=@TeacherEmail,
						TeacherGenderName=@TeacherGenderName,
						TeacherDOB=@TeacherDOB,
						TeacherCountryId=@TeacherCountryId,
						TeacherStateId=@TeacherStateId,
						TeacherCityId=@TeacherCityId
					where TeacherId=@TeacherId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end


go

--alter table teacher
--drop column teacherStandardId


select * from Teacher


exec Sp_AddEditTeacher null,'Jigar','Prajapati','Prajapati Vas Vav','7600834024','jpprajapati812@gmail.com','Male','2000-01-08','1','1','2'
exec Sp_AddEditTeacher null,'Rahul','Patel','Patel Vas Satlasana','558745659','rahul@gmail.com','Male','1988-01-28','1','1','1'

go









create or alter proc Sp_AddEditSubject
(
	@SubjectId int = null,
	@SubjectName varchar(250)
)
as
begin
	if(@SubjectId is null)
		begin
			begin try
				begin tran
					insert into Subject
					values(@SubjectName)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					update Subject
					set
						SubjectName=@SubjectName
					where SubjectId=@SubjectId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go

exec Sp_AddEditSubject null,'Physics'
exec Sp_AddEditSubject null,'Chemistry'
exec Sp_AddEditSubject null,'Mathematics'
exec Sp_AddEditSubject null,'Gujarati'
exec Sp_AddEditSubject null,'English'






go

create or alter proc Sp_AddDeleteStudentTeacher
(
	@action varchar(250),
	@StudentId int,
	@TeacherId int
)
as
begin
	if (@action='add')
		begin
			begin try
				begin tran
					insert into StudentTeacher
					values(@StudentId,@TeacherId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					delete from StudentTeacher
					where StudentId= @StudentId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end


go

exec Sp_AddDeleteStudentTeacher 'add',1,1
exec Sp_AddDeleteStudentTeacher 'add',1,2
exec Sp_AddDeleteStudentTeacher 'add',2,1

select * from Student
select * from Teacher

select * from StudentTeacher








go

create or alter proc Sp_AddDeleteStudentSubject
(
	@action varchar(250),
	@StudentId int,
	@SubjectId int
)
as
begin
	if (@action='add')
		begin
			begin try
				begin tran
					insert into StudentSubject
					values(@StudentId,@SubjectId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					delete from StudentSubject
					where StudentId=@StudentId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end



go

exec Sp_AddDeleteStudentSubject 'add',1,1
exec Sp_AddDeleteStudentSubject 'add',1,2
exec Sp_AddDeleteStudentSubject 'add',1,3
exec Sp_AddDeleteStudentSubject 'add',2,4




select * from StudentSubject






go

create or alter proc Sp_AddDeleteTeacherSubject
(
	@action varchar(250),
	@TeacherId int,
	@SubjectId int
)
as
begin
	if (@action='add')
		begin
			begin try
				begin tran
					insert into TeacherSubject
					values(@TeacherId,@SubjectId)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end		
	else		
		begin
			begin try
				begin tran
					delete from TeacherSubject
					where TeacherId=@TeacherId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end

go







select * from TeacherSubject

exec Sp_AddDeleteTeacherSubject 'add',1,1
exec Sp_AddDeleteTeacherSubject 'add',1,2
exec Sp_AddDeleteTeacherSubject 'add',1,5
exec Sp_AddDeleteTeacherSubject 'add',2,2
exec Sp_AddDeleteTeacherSubject 'add',2,3


go






select * from [dbo].[City]
select * from [dbo].[Country]
select * from [dbo].[Role]
select * from [dbo].[Standard]
select * from [dbo].[State]
select * from [dbo].[Student]
select * from [dbo].[StudentSubject]
select * from [dbo].[StudentTeacher]
select * from [dbo].[Subject]
select * from [dbo].[Teacher]
select * from [dbo].[TeacherSubject]
select * from [dbo].[User]
select * from [dbo].[UserRole]


select * from sys.objects where type='u'