create database SandeepMVC

use SandeepMVC

CREATE TABLE Employee
(
Id int not null Primary key IDENTITY(1,1),
FirstName varchar(100)  not null,
LastName varchar(100) not null,
Email varchar(100),
AddressId int not null ,
Code varchar(50)
);


CREATE TABLE  Address
(
Id int not null primary key ,
Details varchar(500) not null,
State varchar(50), 
Country varchar(50)
);

ALTER TABLE Employee
ADD FOREIGN KEY (AddressId) REFERENCES Address(Id);


select * FROM Employee
select * FROM Address