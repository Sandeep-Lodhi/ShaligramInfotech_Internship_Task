use Sit375_SandeepDB

Create table Employee
(
 id int not null primary key identity(1,1),
[Name] varchar(100),
Designation varchar(100),
Salery int
);

select * from Employee;

insert into Employee([Name],Designation,Salery) values('sandeep','Web developer',30000);
Create table [Users]
(
id int not null primary key identity(1,1),
[Name] varchar(100),
[Password] varchar(100)
);

insert into users([Name],[Password]) values('user',12)
insert into users([Name],[Password]) values('Customer',123)

CREATE table UserRole
( id int not null primary key identity(1,1)  ,
UserId int foreign key references [Users](id),
[Role] nvarchar(100)
);

--drop table UserRole

select * from Users
select * from UserRole
insert into UserRole (UserId,[Role]) values(1,'Admin');
insert into UserRole (UserId,[Role])values(2,'User');
insert into UserRole (UserId,[Role])values(3,'Customer');
insert into UserRole (UserId,[Role])values(1,'User');
insert into UserRole (UserId,[Role])values(1,'Customer');