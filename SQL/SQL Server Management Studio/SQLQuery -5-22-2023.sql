use SandeepLodhi_SIT363;
--------------------------SELECT ------------

Select * from City;
SELECT Id,CountryName FROM Country;

-------------------SELECT DISTINCT-------------
--SELECT DISTINCT column1, column2, ...
--FROM table_name;

SELECT DISTINCT * FROM Users;

SELECT DISTINCT LastName,Email FROM Users;

---------------------------The SQL WHERE Clause--------------
select * from City where CityName = 'Ahamdabad';

------------------AND | OR | NOT -----------------

SELECT CityName FROM City where CityName = 'Bhopal' OR CityName= 'Thai';

SELECT * FROM City WHERE NOT CityName ='Bhopal';

SELECT Id,StateName,CountryId FROM States where StateName='Buhan' AND  CountryId='2';

-----------ORDER BY ---------------
SELECT * FROM UserType ORDER BY UserTypeName;
SELECT * FROM States Order BY StateName ASC;
SELECT * FROM States Order BY StateName DESC;

----------------- INSERT INTO--------------
INSERT INTO Table_1 (Id,Name,Class,age) VALUES(1,'Sandeep','9',22);
INSERT INTO Table_1 VALUES (2,'Raj','12',23);
INSERT INTO Table_1(Id,Name,Class) VALUES (3,'Varun','14');

SELECT * FROM Table_1;

------------------------- IS NULL | IS NOT NULL---------
SELECT * FROM Table_1 where Name is not null;
SELECT * FROM Table_1 where age is null;

------------------------UPDATE ----------
UPDATE Table_1 SET age= 22 where Id=3;
UPDATE Table_1 SET Name= 'Ujjwal' where Id=3;

------------------DELETE--------------
DELETE FROM Table_1 Where Id= 3;

DELETE FROM Table_1;

---------------------SELECT TOP----------
SELECT TOP number|percent column_name(s) FROM table_name WHERE condition;
SELECT TOP 50 percent CityName FROM City;

SELECT TOP 2 CityName FROM City Where Id <3;
SELECT * FROM City;

--------------------SQL MIN() and MAX() Functions -----------------
SELECT MIN(age) AS Small FROM Table_1;
SELECT MAX(age) AS BIg FROM Table_1;

----------------------SQL COUNT(), AVG() and SUM() Functions----------------
SELECT COUNT(Id) FROM Users;
SELECT AVG(Id) FROM Users;
SELECT SUM(CityId) FROM Users;

SELECT * FROM Users;
------------------------------SQL LIKE Operator---------------
SELECT * FROM Users WHERE Address LIKE 'A%';
SELECT * FROM Users WHERE Address LIKE '_e%';
SELECT * FROM Users WHERE Address LIKE '%d%';
---------------------IN | NOT IN ------------
SELECT * FROM Users WHERE Address IN ('Ahamdabad','Delhi');
SELECT * FROM Users WHERE Address NOT IN ('Ahamdabad','Delhi');
---------------------BETWEEN -------------

SELECT * FROM Users WHERE Id between 2 AND 5;

--------------------SQL Aliases-------------------
SELECT DiagnosisDetails as BemariName FROM Diagnosis;
SELECT * FROM Users as Customers;
----------------------------JOIN---------------------
CREATE TABLE Orders(OrderId int not null primary key, CustomerId  int not null, OrderDate date);

CREATE TABLE Customers(CustomerId int not null Primary key, CustomerName varchar(50),customerAdd varchar(225));

insert into Orders (OrderId,CustomerId,OrderDate) values (1,1,'12-04-2003');
insert into Orders (OrderId,CustomerId) values (2,2),(3,3),(4,4),(5,5),(6,6);
---------
INSERT INTO Customers(CustomerId,CustomerName,customerAdd) values(1,'Sandeep Lodhi','Bhopal');
INSERT INTO Customers(CustomerId,CustomerName,customerAdd) values(2,'RajShah','Ahamdabad'),(3,'Varun','andhra'),(4,'Rohit','Delhi');
SELECT * FROM Orders;
SELECT * FROM Customers;
----------------- INNER JOIN-------------------------
SELECT Orders.OrderId, Customers.CustomerName, Customers.customerAdd,Orders.OrderDate 
From Orders
INNER JOIN Customers 
ON Orders.OrderId = Customers.CustomerId;
----------------------RIGHT JOIN------------------------
SELECT Customers.CustomerId, Customers.CustomerName,Customers.customerAdd,Orders.OrderDate From Customers 
RIGHT JOIN Orders 
ON Customers.CustomerId = Orders.OrderId;

------------------------LEFT JOIN-------------------
SELECT Orders.OrderId, Customers.CustomerName,Orders.OrderDate From Orders
LEFT JOIN Customers
ON Customers.CustomerId=Orders.OrderId;

------------------------------UNION----------

SELECT OrderId FROM Orders
UNION ALL
SELECT CustomerId FROM Customers;

SELECT OrderId FROM Orders
UNION
SELECT CustomerId FROM Customers;

--------------------GROUP BY --------------
SELECT COUNT(Id) AS ID,CountryName  FROM Country GROUP BY CountryName;

-------------------HAVING----------------


SELECT * FROM Users

SELECT Id from Users GROUP BY Id Having COUNT(Id) < 2;

  
SELECT COLUMNNAME FROM TABLENAME 
WHERE Condition
GROUP BY  column_name
Having condition (Aggrigate function)
Order BY column_name(s);
------------------------------------------------------------------------------------------AGAIN

--------------------EXISTS-------------------------

-------------------------The SQL ANY and ALL Operators----------
---------------------SQL SELECT INTO  Statement
-------------------SQL INSERT INTO SELECT Statement

---------------------------CASE------------------------


-------------------------SQL IFNULL(), ISNULL(), COALESCE(), and NVL() Functions--------------------- 

-----------------------Stored Procedures------------------------




----------------------------------------

--ALTER TABLE - ADD Column
ALTER TABLE Table_1 ADD RollNo int ;


--ALTER TABLE - DROP COLUMN
ALTER TABLE Table_1 DROP COLUMN RollNo;

--ALTER TABLE - RENAME COLUMN
sp_rename 'Table_1.RollNo', 'Inroll','Column';

--ALTER TABLE - ALTER/MODIFY DATATYPE  
ALTER TABLE Table_1 ALTER  COLUMN Inroll int (DATATYPE); 
SELECT * FROM Table_1;


--SQL Constraints

--NOT NULL - Ensures that a column cannot have a NULL value

CREATE TABLE New1(Id int not null,Name varchar(225));

ALTER TABLE New1 ALTER COLUMN Id int not null;

--UNIQUE - Ensures that all values in a column are different
  ALTER TABLE New1 ADD UNIQUE(Id);

  CREATE TABLE tableName(Id int not null Unique, name varchar(50), class int not null, age int not null);
  
--PRIMARY KEY - A combination of a NOT NULL and UNIQUE. Uniquely identifies each row in a table
CREATE TABLE priTable(pId int not null Primary key, PName nvarchar(120), Paddress nvarchar(120));

ALTER TABLE PriTable ADD PRIMARY KEY(pId);

ALTER TABLE PriTable ADD CONSTRAINT PK_pId PRIMARY KEY (pId,PName);

--FOREIGN KEY - Prevents actions that would destroy links between tables
--1)
CREATE TABLE Orders (
    OrderID int NOT NULL PRIMARY KEY,
    OrderNumber int NOT NULL,
    PersonID int FOREIGN KEY REFERENCES Persons(PersonID)
);

--2)
CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_PersonOrder FOREIGN KEY (PersonID)
    REFERENCES Persons(PersonID)
);

--3)
ALTER TABLE Orders
ADD FOREIGN KEY (PersonID) REFERENCES Persons(PersonID);

--4)
ALTER TABLE Orders
ADD CONSTRAINT FK_PersonOrder
FOREIGN KEY (PersonID) REFERENCES Persons(PersonID);
  
--CHECK - Ensures that the values in a column satisfies a specific condition

--1)
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int CHECK (Age>=18)
);


--2)
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    City varchar(255),
    CONSTRAINT CHK_Person CHECK (Age>=18 AND City='Sandnes')
);


--DEFAULT - Sets a default value for a column if no value is specified

ALTER TABLE Persons
ADD CONSTRAINT df_City
DEFAULT 'Sandnes' FOR City;


CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    City varchar(255) DEFAULT 'Sandnes'
);

CREATE TABLE Orders (
    ID int NOT NULL,
    OrderNumber int NOT NULL,
    OrderDate date DEFAULT GETDATE()
);


--CREATE INDEX - Used to create and retrieve data from the database very quickly

CREATE INDEX index_name
ON table_name (column1, column2, ...);


CREATE UNIQUE INDEX index_name
ON table_name (column1, column2, ...);

--DROP INDEX
DROP INDEX table_name.index_name;



----------------------------SQL AUTO INCREMENT Field-----------------------

CREATE TABLE Persons (
    Personid int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);


----------------------------SQL Dates---------------------


------------------------VIEW---------------

CREATE VIEW [Brazil Customers] AS
SELECT CustomerName, ContactName
FROM Customers
WHERE Country = 'Brazil';

SELECT * FROM [Brazil Customers];


--------------------------SQL Injection------------




---DATA TYPES 
--- FUNCTIONS








