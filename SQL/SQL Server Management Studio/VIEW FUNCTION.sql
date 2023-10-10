use SandeepLodhi_SIT363

SELECT * FROM Employees

--VIEW :  


CREATE VIEW Em_View 
AS 
  SELECT EmployeeID,FristName,LastName FROM Employees

SELECT * FROM Em_View

SELECT * FROM sys.tables
SELECT * FROM class

CREATE VIEW Class_view AS
SELECT section,FirstName,LastName,class,rollNo,age From class 

SELECT * FROM Class_view;
-----------------------------------------------------------
--FUNCTION ::

--CREATE FUNCTION dbo.func1() 
--RETURNS int 
--AS  
--BEGIN  
--   RETURN 12  
--END


--SELECT * FROM func1(int) 

--DROP FUNCTION  dbo.func1;


--It creates a table-valued function to get employees  
CREATE FUNCTION fun_Employee()  
RETURNS TABLE  
AS  
 RETURN (SELECT * FROM Employees); 

 SELECT * FROM fun_Employee();