
create function fun()
returns table
as 
   return (SELECT * FROM Orders);

  SELECT * FROM fun();


  CREATE VIEW demoView
  as
  SELECT * FROM Persons

  SELECT * FROM demoView


  CREATE PROC sp_Test
     (@ID int,@LastName varchar(225),@FirstName varchar(225),@Age int)
  AS 
    
  BEGIN 
     insert into Persons(ID,LastName,FirstName,Age)  values (@ID,@LastName,@FirstName,@Age)
  END

  exec sp_Test 3,'Dhote','Krunal',23
   
drop proc Sp_Test
  SELECT * FROM  Persons

  CREATE Proc Sp_Select
  AS
  BEGIN 
     SELECT * FROM Persons
  END

 EXEC Sp_Select