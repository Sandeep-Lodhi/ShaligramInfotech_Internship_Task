create database Sit375DB

use Sit375DB;

CREATE TABLE [User]
(
id  int not null primary key identity(1,1),
[Name] varchar(50),
Email varchar(50),
Contact varchar(50),
[Password]  varchar(50)
);

drop table [Order]
CREATE TABLE [Order]
(
OrderId int not null primary key identity(1,1),
Details varchar(100),
Amount Decimal(12,2),
[Status] varchar(100),
Cust_Id int foreign key references [User](id) DEFAULT 2
);

select * from [User]
select * from [Order]

truncate table [User]

insert  into [User]([Name],Email,Contact,[Password])
values('sandeep','sandeep@gmail.com','1233445566','Sit@321#')

insert into [Order](Details,Amount,[Status],Cust_Id) values
('Daveli,Samosa,Chhole',23.33,'paid',1)
