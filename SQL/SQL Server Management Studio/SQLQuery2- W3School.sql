--SELECT - extracts data from a database
--UPDATE - updates data in a database
--DELETE - deletes data from a database
--INSERT INTO - inserts new data into a database
--CREATE DATABASE - creates a new database
--ALTER DATABASE - modifies a database
--CREATE TABLE - creates a new table
--ALTER TABLE - modifies a table
--DROP TABLE - deletes a table
--CREATE INDEX - creates an index (search key)
--DROP INDEX - deletes an index
------------------------------------------ 
 SELECT ---------

 SELECT * FROM Table1;
 SELECT * FROM Table2;
 SELECT * FROM Table3;
 SELECT EmployeeID, CustomerID, OrderID FROM Table2;
 SELECT DISTINCT OrderID FROM Table2;
 SELECT * FROM Table2 WHERE EmployeeID > 3;
 SELECT * FROM Table3 WHERE LastName  LIKE 'F%';
                       -- AND OR NOT
-- AND 
SELECT CustomerName,ContactName  FROM Table1 WHERE CustomerID= 1 AND ContactName='Maria Anders';
 -- OR 
 SELECT OrderID,CustomerID  FROM Table2 WHERE CustomerID= 2 OR OrderID= 10309;

-- NOT
 SELECT OrderID,CustomerID  FROM Table2 WHERE NOT OrderID= 10309;

 -----  ORDER BY 
 SELECT EmployeeID FROM Table2 ORDER BY EmployeeID ASC;
 SELECT FirstName, LastName,BirthDate FROM Table3 Order BY BirthDate DESC;
 SELECT * FROM Table2 ORDER BY EmployeeID ;

 --INSERT INTO QUERY 

 INSERT INTO Table3 values(1,'Sandeep','Lodhi','13/04/2001','EmpID1.pic');
 INSERT INTO Table2 (OrderID, CustomerID,EmployeeID,ShipperID) values (23421,33,43,5);

 -- IS NULL Operator or IS NOT NULL Opetator 

 SELECT CustomerName, ContactName, Address FROM Table1 WHERE Address IS NOT NULL;

 SELECT * FROM Table2 WHERE OrderDate  IS NULL;

 UPDATE  ---- update data into table 

 UPDATE Table2 SET EmployeeID= 77 Where OrderID= 10308;

 UPDATE Table2 SET OrderDate='12/07/2023' where CustomerID = 33;

  -- DELETE 
SELECT * FROM Table1;

DELETE FROM Table2 WHERE EmployeeID=3;
DELETE FROM TABLE3

INSERT INTO Table3 VALUES (0202,'LODHI','SANDEEP','13/04/2001','SANDEEP.PNG');

 --MIN() MAX() PRACTICE BILOW  
 SELECT MIN(PostalCode) FROM Table1 -- WHERE condition;

 SELECT MAX(PostalCode) FROM Table1  

 SELECT MIN(PostalCode) AS LargestPostalCode FROM Table1;

 -- SQL COUNT(), AVG() and SUM() Functions
 SELECT COUNT(CustomerID) AS Entries FROM Table1;
 SELECT AVG(CustomerID) AS Average   FROM Table1;
 SELECT SUM(CustomerID) AS Average   FROM Table1;

 --  LIKE EXAMPLE

 SELECT * FROM Table1 WHERE CustomerName LIKE '_n%';
  -- IN
 SELECT * FROM Table1 WHERE country  IN ('Germany');

  SELECT * FROM Table1 WHERE country  NOT IN ('Germany');

   -- BETWEEN 
   SELECT *  FROM Table1 WHERE PostalCode BETWEEN 1 AND 3;


  -- SQL Aliases
  SELECT City AS State FROM Table1;

 --  UNION 
  SELECT CustomerID FROM table1
  UNION
  SELECT ShipperID FROM table2;


  -- GROUP BY
  SELECT COUNT(CustomerID) as id, country
  FROM Table1
  GROUP BY country;

SELECT COUNT(CustomerID), country
FROM Table1
GROUP BY country
ORDER BY COUNT(CustomerID) DESC;


-- having 
SELECT COUNT(CustomerID), country
FROM Table1
GROUP BY country
HAVING COUNT(CustomerID) > 1;

-- EXISTS
SELECT CustomerID
FROM Table1
WHERE EXISTS (SELECT OrderID FROM Table2 WHERE Table1.CustomerID = Table2.OrderID AND EmployeeID = 43);

-- SQL ANY and ALL Operators


-- CASE 
   select * from class
   SELECT FirstName, LastName, fees
FROM class
ORDER BY
(CASE
    WHEN LastName IS NULL THEN country
    ELSE LastName
END);

-- SQL IFNULL(), ISNULL(), COALESCE(), and NVL() Functions

---------------------
--Q1)
SELECT 5, 10, 15;
--Q2)
SELECT 'This is SQL Exercise, Practice and Solution' AS CC ;
--Q3)
SELECT 10 + 15;
--Q4)
SELECT 10 + 15 - 5 * 2;
--Q5)
select fees from class;
--Q6)
SELECT LastName, FirstName , fatherName from class;
--Q7)
select * from Orders where OrderId= 10308;
--Q8)
SELECT * FROM Table1 where country ='Germany';
--Q9)
SELECT DISTINCT CustomerID FROM Table1;
--Q10)

