use SandeepLodhi_SIT363
--Table 1: "Employees"

CREATE TABLE Employees
(
EmployeeID int not null,
LastName varchar(225),
FristName varchar(225),
Title varchar(225),
BirthDate date,
HireDate date,
ReportsTo int,
Address varchar(225)
);

--Table 2: "Orders"

CREATE TABLE Orders
(
 OrderID int not null,
 CustomerID int,
 EmployeeID int,
 OrderDate date,
);

--Table 3: "Customers"

CREATE TABLE Customers
(
  CustomerID int not null,
  CompanyName varchar(225),
  ContactName varchar(225),
  ContactTitle varchar(225),
  Address varchar(225),
  City varchar(225),
  Country varchar(225)
);

SELECT * FROM Employees;
SELECT * FROM Orders;
SELECT * FROM Customers;

INSERT INTO Employees (EmployeeID,LastName,FristName,Title,BirthDate,HireDate,ReportsTo,Address) 
VALUES (1,'Smith','John','Manager','1990-01-01','2010-01-01',2,'123 Main St'),
   (2, 'Johnson', 'Karen', 'Assistant Manager', '1995-05-15', '2015-02-10', 1, '456 Elm St'),
    (3, 'Lee', 'David', 'Sales Representative', '1992-11-21', '2012-09-01', 1, '789 Oak Ave'),
    (4, 'Garcia', 'Maria', 'Sales Representative', '1991-07-04', '2014-05-01', 2, '321 Pine St'),
	(5,'Rajade', 'Bhaskar' ,'Trainee', '2001-06-09' , '2023-02-06' , 2 , '234 Bopal Gam Ahamdabad' )
		(6,'Raj','Shah','Developer','1999-07-12','2014-05-01',3,' 435 Ahamdabad Gujrat'),
	(7,'Krunal','Dhote','Employee','2002-03-15','2012-06-09',4,'Amravati Maharastra'),
	(8,'Pandit','Rohit','IT department','1998-05-07','1988-04-02',2,'Sector 15 New Ashoka Garden Delhi')
	(9,'Lodhi','Sandeep','Developer','2001-04-13','2023-02-06',2,'Bhopal');

INSERT INTO Employees (EmployeeID,LastName,FristName,Title,BirthDate,HireDate,ReportsTo,Address) 
VALUES
	 (10,'Godke','Ujjwal','data Scientiest','1998-09-27','2023-04-04',2,'Anand Nagar Bhopal');



INSERT INTO Orders
(OrderID,CustomerID,EmployeeID,OrderDate)
VALUES
(1,123,4,'2023-04-11'),
(2, '123', 4, '2023-04-11'),
(3, '124', 8, '2001-05-15'),
(4, '125', 2, '2002-09-17'),
(5, '126', 7, '2003-06-19'),
(6, '127', 3, '2006-02-22'),
(7, '128', 9, '2007-08-27'),
(8, '129', 5, '2005-03-19'),
(9, '120', 1, '2009-11-17'),
(10, '121', 6, '2011-05-13'),
(11, '122', 01, '2015-06-25');

INSERT INTO Customers
(CustomerID,CompanyName ,ContactName,ContactTitle,Address,City,Country) 
VALUES
(1,'ABC Company','John Smith','Sales Manager','123 Main St','Anytown','US'),
(2,'Microshoft','satya Nadela','developer','Ahamdabad','Gujrat','India'),
(3,'Google','Sundar Pichai','Team Leader','yamuna bank','California','US'),
(4,'Shaligram','Parth patel','Head','ahamdabad','Gujrat','India'),
(5,'capgemini','Amardeep','Employee','Ashoka garden', 'Indore','india' ),
(6,'enfosys','narayan murti','CEO','new bumbai','maharastra','New York'),
(7,'accenture','john doe','manager','california','foreign','New york'),
(8,'Cognizant','fintch','Founder','ifel park','london','US');

------------------------------------------------------------------------ 
--Q1.)Write a SQL query to retrieve the list of all orders made by customers in the "USA".

SELECT * FROM Orders right join Customers on Orders.OrderID = Customers.CustomerID Where Country = 'US';

--Q2.) Write a SQL query to retrieve the list of all customers who have placed an order.
 SELECT * From Customers left JOIN Orders on Customers.CustomerID= Orders.OrderId;

 --Q3.)Write a SQL query to retrieve the list of all employees who have not yet placed an order.

 SELECT  * From Orders LEFT JOIN Employees on  Employees.EmployeeID = Orders.OrderId   -- WHERE Employees.EmployeeID != Orders.OrderId;

 --Q4)Write a SQL query to retrieve the list of all employees who have placed an order.
 SELECT * From Employees LEFT OUTER JOIN Orders on   Orders.OrderId  = Employees.EmployeeID;

 --Q5)Write a SQL query to retrieve the list of all customers who have not yet placed an order.

 SELECT * From Customers RIGHT JOIN Orders on Customers.CustomerID = Orders.OrderId ;

 --Q6) Write a SQL query to retrieve the list of all customers who have placed an order, along with the order date.
 SELECT Customers.ContactName,Orders.OrderDate FROM Customers RIGHT JOIN Orders ON Customers.CustomerID = Orders.OrderID;

 --Q7)Write a SQL query to retrieve the list of all orders placed by a particular customer.
 SELECT * FROM Customers RIGHT JOIN Orders ON Customers.CustomerID = Orders.OrderId Where Customers.CustomerID= 1;

 --08)Write a SQL query to retrieve the list of all orders placed by a particular employee.

 SELECT * FROM  Employees RIGHT JOIN Orders ON Employees.EmployeeID =  Orders.OrderID WHERE Employees.FristName ='John';

 --Q9)Write a SQL query to retrieve the list of all orders placed by a particular customer on a particular date.
 SELECT * FROM Customers right join Orders ON Customers.CustomerID = Orders.OrderID  WHERE Orders.OrderDate='2023-04-11';

 --Q10) Write a SQL query to retrieve the list of all customers who have not yet placed an order, sorted by their country.
 SELECT * FROM Customers inner JOIN Orders ON Customers.CustomerID  = Orders.OrderID Where  Customers.CustomerID IS NULL AND Country = 'US';

 --Q11) Write a SQL query to retrieve the list of all orders placed by customers in the "USA", sorted by order date.

  SELECT * FROM Customers inner JOIN Orders ON Customers.CustomerID  = Orders.OrderID Where  Country = 'US';

  --Q12)Write a SQL query to retrieve the list of all employees who have not yet placed an order, sorted by last name.
    SELECT * FROM  Employees RIGHT JOIN Orders ON Employees.EmployeeID =  Orders.OrderID WHERE Orders.OrderID is null  Order BY  Employees.LastName;

	--Q13) Write a SQL query to retrieve the list of all customers who have placed an order, sorted by their company name.
	SELECT * FROM Customers inner JOIN Orders ON Customers.CustomerID  = Orders.OrderID order by Customers.CompanyName ;

	-- Q14) Write a SQL query to retrieve the list of all employees who have placed an order, sorted by their hire date.
	SELECT * FROM  Employees RIGHT JOIN Orders ON Employees.EmployeeID =  Orders.OrderID  Order BY  Employees.HireDate;
	--Q15)Write a SQL query to retrieve the list of all customers who have placed an order on a particular date, sorted by their company name.
	SELECT * FROM Customers inner JOIN Orders ON Customers.CustomerID  = Orders.OrderID Where Orders.OrderDate = '2023-04-11' order by Customers.CompanyName;

	--Q16) Write a SQL query to retrieve the list of all customers who have placed an order, along with the employee who handled the order.
	SELECT * FROM  Employees RIGHT JOIN Orders ON Employees.EmployeeID =  Orders.OrderID  WHERE Employees.ReportsTo = 2;

	--Q17)Write a SQL query to retrieve the list of all employees who have placed an order, along with the customer who placed the order.
	 SELECT Employees.FristName,Employees.LastName , Orders.OrderID, Orders.customerID,Orders.OrderDate From Employees left join Orders ON Employees.EmployeeID = Orders.OrderId;

	 --Q18)Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date.
	 SELECT Customers.CustomerID,Customers.ContactName , Orders.OrderDate FROM Customers left join Orders ON Customers.CustomerID = Orders.OrderId;

	 --Q19)Write a SQL query to retrieve the list of all orders placed by employees who were born in a particular year, along with the employee name and order date.

	 SELECT Employees.EmployeeID , Employees.FristName, Orders.OrderDate from Employees right join Orders ON Employees.EmployeeID = Orders.OrderID Order by OrderDate;
	 --Q20) Write a SQL query to retrieve the list of all customers who have placed an order, along with the customer name, order date, and employee who handled the order.
	   Select Customers.CustomerID,Customers.ContactName, Orders.OrderDate, Employees.FristName,Employees.LastName FROM ((Customers right join Orders ON Customers.CustomerID = Orders.OrderID)
	   right join Employees ON Employees.EmployeeID = Orders.OrderId)

	  -- Q21)
SELECT * FROM Employees;
SELECT * FROM Orders;
SELECT * FROM Customers;