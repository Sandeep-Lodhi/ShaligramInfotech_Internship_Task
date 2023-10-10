  USE SandeepLodhi_SIT363
  --Store Procesure create here

  --for Creating procesure 
  create proc sp_class
  AS
  BEGIN 
     SELECT * FROM dbo.class
  END 

  EXEC sp_class
  -- ========================================
  --for modify procesure create here
  CREATE  PROC spClass_UpdateDY
  @id  int
  AS 
  BEGIN 
     UPDATE dbo.class SET fatherName='dady' where section= @id;
  END

  EXEC spClass_UpdateDY 3
  --  ----------------------------------------
  select * from Students;
  --create procesure for insert data into table 
  CREATE  PROC spClass_INSERT 

    (@id int,@firstname varchar(225),@lastname varchar(225), @age int, @joinDAte date)
  AS 
  BEGIN
     insert into Students(id,firstname,lastname,age,joinDAte) values(@id, @firstname,@lastname,@age,@joinDAte) 
  END
  
 EXEC spClass_INSERT 4,'Varun','kumar',24,'2023-12-06'
   -- ==============================

   --we can executue procesure in three types 
   1) spName
   2) EXECUTE spName
   3) EXEC  spName

   -- ====================
   SELECT * FROM Persons
   BEGIN TRAN
    UPDATE dbo.Persons SET addressName = 'peche jata' where personId= 3;
   COMMIT TRAN
   ROLLBACK TRAN
   WITH(NOLOCK);

   --for see the procesure actualy what it is.
   sp_helptext spClass_INSERT

   DROP 

   ----------------------------------------------------------------------------------
   SELECT * FROM  class

   --  FETCH  ROWS  
SELECT section, FirstName, Class+rollNo+age AS total
FROM class
ORDER BY Class+rollNo+age DESC
OFFSET 0 ROWS
FETCH NEXT 3 ROWS ONLY;