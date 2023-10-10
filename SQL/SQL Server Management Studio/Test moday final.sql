Create database Sandeep_5_6_2023
use Sandeep_5_6_2023

--drop database Sandeep_5_6_2023

--Country
CREATE TABLE Country
(
CountryId int not null primary key  IDENTITY(1,1),
CountryName VARCHAR(50) NOT NULL
);


--States 
CREATE TABLE States
(
StateId int not null  primary key identity(1,1),
CountryId int not null foreign key references  Country(CountryId),
StateName varchar(50)  NOT NULL 
);


--Cities 
CREATE TABLE Cities
(
CityId int not null primary key identity(1,1),
CountryId int not null foreign key references Country(CountryId),
StateId int not null foreign key references States(StateId),
CitiesName varchar(50) not null
);

--UsersType
CREATE TABLE UsersType
(
UserTypeId  int not null primary key identity(1,1),
UserTypeName varchar(50)  Unique
);

--Users 
CREATE TABLE Users
(
UserId int not null PRIMARY KEY identity(1,1),
UserName varchar(50) UNIQUE,
UserType int not null foreign key references UsersType(UserTypeId),
Email varchar(50) not null UNIQUE, 
ContactNo varchar(10) CHECK(LEN(ContactNo)>=10),
Address varchar(100),
CountryId int not null foreign key references Country(CountryId),
StateId int not null foreign key references States(StateId),
CityId int not null foreign key references Cities(CityId)
);

--Menu
CREATE TABLE Menu
(
MenuId int not null Primary key identity(1,1),
MenuName varchar(100),
Rates decimal(5,3)
); 

--Orders
CREATE TABLE Orders
(
OrderId int not null PRIMARY KEY IDENTITY(1,1),
UsersId_Cusromer int not null foreign key references Users(UserId),
UserId_Waiter int not null foreign key references Users(UserId),
Menus varchar(100),
TotalBillAmount Decimal(5,3),
OrdersDates DATE
);

--INSERT INTO Country
INSERT INTO Country(CountryName) VALUES('India');
INSERT INTO Country(CountryName) VALUES('UK');
INSERT INTO Country(CountryName) VALUES('USA');
INSERT INTO Country(CountryName) VALUES('China');
INSERT INTO Country(CountryName) VALUES('Pakistan');

--INSERT INTO States
INSERT INTO States(CountryId,StateName) VALUES (1,'Gujrat');
INSERT INTO States(CountryId,StateName) VALUES (2,'United State');
INSERT INTO States(CountryId,StateName) VALUES (3,'California');
INSERT INTO States(CountryId,StateName) VALUES (4,'Bhuhan');
INSERT INTO States(CountryId,StateName) VALUES (5,'Karachi');

--INSERT INTO Cities
INSERT INTO Cities(CountryId,StateId,CitiesName) values(1,1,'Ahandabad');
INSERT INTO Cities(CountryId,StateId,CitiesName) values(2,2,'United Amirates');
INSERT INTO Cities(CountryId,StateId,CitiesName) values(3,3,'califo Town');
INSERT INTO Cities(CountryId,StateId,CitiesName) values(4,4,'Huhang');
INSERT INTO Cities(CountryId,StateId,CitiesName) values(5,5,'Multan');

--INSERT INTO UserType
INSERT INTO UsersType(UserTypeName) Values('Manager');
INSERT INTO UsersType(UserTypeName) Values('Waiter');
INSERT INTO UsersType(UserTypeName) Values('Customer');
INSERT INTO UsersType(UserTypeName) Values('Shef');
INSERT INTO UsersType(UserTypeName) Values('Owner');

--INSERT INTO Users
INSERT INTO Users(UserName,UserType,Email,ContactNo,Address,CountryId,StateId,CityId) 
VALUES('Sandeep',1,'sandeep@gmail.com','6266921342','Bhopal Mp',1,1,1);

INSERT INTO Users(UserName,UserType,Email,ContactNo,Address,CountryId,StateId,CityId) 
VALUES('Nisant',3,'nisant@gmail.com','6266921432','Jabalpur',2,2,2);

INSERT INTO Users(UserName,UserType,Email,ContactNo,Address,CountryId,StateId,CityId) 
VALUES('Rohit',2,'rohit@gmail.com','6263921342','Delhi',3,3,3);

INSERT INTO Users(UserName,UserType,Email,ContactNo,Address,CountryId,StateId,CityId) 
VALUES('Sagar',2,'sagar@gmail.com','6266925342','gujrat',4,4,4);

INSERT INTO Users(UserName,UserType,Email,ContactNo,Address,CountryId,StateId,CityId) 
VALUES('Raj',3,'raj@gmail.com','6266923142','Ahamdabad',5,5,5);

--INSERT INTO Menu
INSERT INTO Menu(MenuName,Rates) VaLUES('Dosa',40);
INSERT INTO Menu(MenuName,Rates) VaLUES('Bada Pao',20);
INSERT INTO Menu(MenuName,Rates) VaLUES('Gujrati Thali',80);
INSERT INTO Menu(MenuName,Rates) VaLUES('Chau Meen',60);
INSERT INTO Menu(MenuName,Rates) VaLUES('Samosa',20);

insert into Orders(UsersId_Cusromer,UserId_Waiter,Menus,TotalBillAmount,OrdersDates)
values(3,2,'Dosa,Bada Pao',60,'2023-6-1');

insert into Orders(UsersId_Cusromer,UserId_Waiter,Menus,TotalBillAmount,OrdersDates)
values(3,2,'Dosa,Gujrati Thali',90,'2023-6-2');

insert into Orders(UsersId_Cusromer,UserId_Waiter,Menus,TotalBillAmount,OrdersDates)
values(3,2,'Dosa,samosa',60,'2023-6-3');

insert into Orders(UsersId_Cusromer,UserId_Waiter,Menus,TotalBillAmount,OrdersDates)
values(3,2,'Chao Meen,Samosa',80,'2023-6-4');

insert into Orders(UsersId_Cusromer,UserId_Waiter,Menus,TotalBillAmount,OrdersDates)
values(3,2,'Dosa,Bada Pao',50,'2023-6-5');

 ------------------------------------------------------------------------------------------------------1
--1) Create A function to retrive all the menus and their price?

CREATE FUNCTION fn_AllMenus()
RETURNS Table
AS
RETURN (SELECT MenuName,Rates AS Price from Menu)

SELECT * FROM fn_AllMenus()

--**************************************************************************2
--2) CREATE Prametrized Procesure 
Alter PROC sp_CustomrOrderList
 @DateFirst Date = NULL,
 @DateSecond Date = NULL
AS
BEGIN 
IF @DateFirst IS NOT NULL AND @DateSecond IS NOT NULL  
BEGIN 
 SELECT Users.UserName,
CONCAT(Users.Address,',',Country.CountryName,',',States.StateName,',',Cities.CitiesName) AS Address,
Orders.OrderId,
Orders.TotalBillAmount AS BillAmount,
Orders.OrdersDates FROM Users
LEFT JOIN Country ON Users.CountryId =  Country.CountryId
LEFT JOIN States ON Users.StateId= States.StateId
LEFT JOIN Cities ON Users.CityId = Cities.CityId 
LEFT JOIN Orders ON Users.UserId = Orders.OrderId
WHERE OrdersDates BETWEEN @DateFirst AND @DateSecond;
END
ELSE
BEGIN 
SELECT Users.UserName,
CONCAT(Users.Address,',',Country.CountryName,',',States.StateName,',',Cities.CitiesName) AS Address,
Orders.OrderId,
Orders.TotalBillAmount AS BillAmount,
Orders.OrdersDates FROM Users
LEFT JOIN Country ON Users.CountryId =  Country.CountryId
LEFT JOIN States ON Users.StateId= States.StateId
LEFT JOIN Cities ON Users.CityId = Cities.CityId 
LEFT JOIN Orders ON Users.UserId = Orders.OrderId;
END
END

EXEC sp_CustomrOrderList 
EXEC sp_CustomrOrderList '2023-06-02', '2023-06-04'

---********************========================================================= 3
--Q3) create a  parametrized store procesure to retrive order info as per the customer name---

ALTER  PROC sp_OrderInfo
@CustomerName VARCHAR(50)
AS
BEGIN 
IF @CustomerName is not null -- EXISTS(SELECT UserName FROM Users WHERE UserName = @CustomerName)
BEGIN
SELECT Orders.OrderId,
U1.UserName AS [Customr Name],
U2.UserName AS [Waiter Name],
Orders.TotalBillAmount AS BillAmount,
Orders.OrdersDates FROM Orders
LEFT JOIN Users  U1 ON Orders.UsersId_Cusromer = U1.UserId
LEFT JOIN Users U2 ON Orders.UserId_Waiter =  U2.UserId
WHERE   U1.UserName = @CustomerName --(SELECT UserName FROM Users WHERE UserName = @CustomerName) 
END
ELSE 
BEGIN 
SELECT Orders.OrderId,
Orders.UsersId_Cusromer AS [Customr Name],
Orders.UserId_Waiter AS [Waiter Name],
Orders.TotalBillAmount AS BillAmount,
Orders.OrdersDates FROM Orders
LEFT JOIN Users  U1 ON Orders.UsersId_Cusromer = U1.UserId
LEFT JOIN Users U2 ON Orders.UserId_Waiter =  U2.UserId;
END 
END

EXEC sp_OrderInfo 'Nisant'
EXEC sp_OrderInfo 'Raj'
--EXEC sp_OrderInfo 


SELECT * FROM UsersType
SELECT * FROM Users

--==================================================================================== 4
--Q4) create a store inside it made a function for retriving menus as per customer name

-- FUNCTION 
ALTER  FUNCTION fn_Customer(@UserName VARCHAR(220))
RETURNS VARCHAR(220)
AS 
begin
DECLARE @CustomerName VARCHAR(220)
SELECT @CustomerName = Orders.Menus  FROM Users
INNER JOIN Orders ON Users.UserId = Orders.UsersId_Cusromer
WHERE UserName = @UserName
RETURN @CustomerName 
end

--select fn_Customer()

-- PROCESURE 
ALTER  PROC sp_MenusList
 @CustomerName VARCHAR(220)
AS
BEGIN
IF EXISTS (SELECT  * FROM Users WHERE UserName = @CustomerName AND UserType = 3)
BEGIN
  SELECT DISTINCT Users.UserName,dbo.fn_Customer(Users.UserName) AS All_Menu FROM Users
  INNER JOIN Orders ON Users.UserId = Orders.UsersId_Cusromer
  WHERE UserName = @CustomerName
  --order by OrdersDates
END
ELSE
BEGIN 
PRINT 'No Customer Found'
END
END

EXEC sp_MenusList 'Nisant'
EXEC sp_MenusName 'Sagar'
select * from Users

--SELECT QUERY
SELECT * FROM Country
SELECT * FROM States
SELECT * FROM Cities
SELECT * FROM UsersType
SELECT * FROM Users
SeLeCT * FROM Menu
SELECT * FROM Orders
