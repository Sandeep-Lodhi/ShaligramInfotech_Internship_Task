use SandeepLodhi_SIT363

SELECT * from CountryT
SELECT * from StatesT
SELECT * from Cities
SELECT * from UsersType
SELECT * from UsersT
SELECT * from Menu
SELECT * from OrdersT

------------------------
CountryId	CountryName
1	         India
2	         China
3	         Pakistan
4	         America

----------------------------
StateId	CountryId	StateName
1	1	Madhya Pradesh
2	2	Buhang
3	3	Karachi
4	4	California
-------------------------------
UserTypeId	UserTypeName
3	Customer
1	Manager
4	Resepsnist
2	Waiter
----------------------------------
CityId	CountryId	StateId	CitiesName
1	1	1	Bhopal
2	2	2	Shanghai
3	3	3	Multan
4	4	4	Top Town
------------------------------------------
UserTypeId	UserTypeName
3	Customer
1	Manager
4	Resepsnist
2	Waiter
--------------------------------------------
UsersId	UserName	UserType	Email	ContactNo	Address	CountryId	StateId	CityId
1	Sandeep	1	sandeep@gmail.com	6266921342	Bhopal,Madhya Pradesh	1	1	1
2	Varun	2	varun@gmail.com	5452345325	Bhopal,Madhya Pradesh	2	2	2
3	Raj	3	raj@gmail.com	6266921346	Bhopal,Madhya Pradesh	3	3	3
4	Rohit	4	rohit@gmail.com	6266921382	Bhopal,Madhya Pradesh	4	4	4
-------------------------------------------------------------------------------
MenuId	ManuName	Rates
1	Gujrati thali	80
2	Masala Dosa	40
3	panjabi thali	130
4	samosa	20
------------------------------------------------
OrderId	UserId_Customer	UserId_Waiter	Menu	TotalBillAmount	OrderDates
1	3	2	Samosa,Masala Dosa	60	2023-04-15
2	3	2	Samosa,Masala Dosa,Gujrati thali	140	2023-04-18
3	1	2	Samosa,Masala Dosa,Panjabi thali	170	2023-04-22

--======================================================================================
--Q1) 
CREATE FUNCTION AllMenues()
RETURNS TABLE
AS
RETURN SELECT Menu,TotalBillAmount AS Price FROM OrdersT;

SELECT * FROM AllMenues();

--===============================================================================
--Q2)CREATE STORE PROCESURE 

ALTER PROC CustomerList
 @startDate Date = NULL,
 @EndDate Date = NULL
AS
BEGIN 
IF @startDate IS NOT NULL AND @EndDate IS NOT NULL  
BEGIN 
 SELECT UsersT.UserName,
CONCAT(UsersT.Address,',',CountryT.CountryName,',',StatesT.StateName,',',Cities.CitiesName) AS Address,
OrdersT.OrderId,
OrdersT.TotalBillAmount,
OrdersT.OrderDates FROM UsersT
LEFT JOIN CountryT ON UsersT.CountryId =  CountryT.CountryId
LEFT JOIN StatesT ON UsersT.StateId= StatesT.StateId
LEFT JOIN Cities ON UsersT.CityId = Cities.CityId 
LEFT JOIN OrdersT ON UsersT.UsersId = OrdersT.OrderId
WHERE OrderDates BETWEEN @startDate AND @EndDate;
END
ELSE
BEGIN 
SELECT UsersT.UserName,
CONCAT(UsersT.Address,',',CountryT.CountryName,',',StatesT.StateName,',',Cities.CitiesName) AS Address,
OrdersT.OrderId,
OrdersT.TotalBillAmount,
OrdersT.OrderDates FROM UsersT
LEFT JOIN CountryT ON UsersT.CountryId =  CountryT.CountryId
LEFT JOIN StatesT ON UsersT.StateId= StatesT.StateId
LEFT JOIN Cities ON UsersT.CityId = Cities.CityId 
LEFT JOIN OrdersT ON UsersT.UsersId = OrdersT.OrderId;
END
END

EXEC CustomerList 
EXEC CustomerList '2023-04-15' ,'2023-04-22'

SELECT * FROM OrdersT 

---********************=========================================================
--Q3) create a store procesure---

ALTER PROC OrderInfo
@CustomerName VARCHAR(50)
AS
BEGIN 
IF  EXISTS(SELECT UserName FROM UsersT WHERE UserName = @CustomerName)
BEGIN
SELECT OrdersT.OrderId,
U1.UserName AS [Customr Name],
U2.UserName AS [Waiter Name],
OrdersT.TotalBillAmount AS BillAmount,
OrdersT.OrderDates FROM OrdersT
LEFT JOIN UsersT  U1 ON OrdersT.UserId_Customer = U1.UsersId
LEFT JOIN UsersT U2 ON OrdersT.UserId_Waiter =  U2.UsersId
WHERE   U1.UserName = @CustomerName --(SELECT UserName FROM UsersT WHERE UserName = @CustomerName) 
END
ELSE 
BEGIN 
SELECT OrdersT.OrderId,
OrdersT.UserId_Customer AS [Customr Name],
OrdersT.UserId_Waiter AS [Waiter Name],
OrdersT.TotalBillAmount AS BillAmount,
OrdersT.OrderDates FROM OrdersT
LEFT JOIN UsersT  U1 ON OrdersT.UserId_Customer = U1.UsersId
LEFT JOIN UsersT U2 ON OrdersT.UserId_Waiter =  U2.UsersId;
END 
END


EXEC OrderInfo 'Sandeep'

--====================================================================================
--Q4)

-- FUNCTION 
ALTER FUNCTION CustomerFunc(@UserName VARCHAR(220))
RETURNS VARCHAR(220)
AS 
begin
DECLARE @CustomerName VARCHAR(220)--BEGIN
SELECT @CustomerName = OrdersT.Menu FROM UsersT
INNER JOIN OrdersT ON UsersT.UsersId = OrdersT.UserId_Customer
WHERE UserName = @UserName--END
RETURN @CustomerName 
end

-- PROCESURE 
ALTER PROC MenusName
 @CustomerName VARCHAR(220)
AS
BEGIN
IF EXISTS (SELECT  * FROM UsersT WHERE UserName = @CustomerName AND UserType = 3)
BEGIN
  SELECT UsersT.UserName,dbo.CustomerFunc(UsersT.UserName) FROM UsersT
  INNER JOIN OrdersT ON UsersT.UsersId = OrdersT.UserId_Customer
  WHERE UserName = @CustomerName
END
ELSE
BEGIN 
PRINT 'No Customer Found'
END
END

EXEC MenusName 'Sandeep'
select * from UsersT
