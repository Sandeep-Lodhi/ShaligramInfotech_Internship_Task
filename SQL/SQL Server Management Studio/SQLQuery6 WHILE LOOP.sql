--select * from Persons;
DEClARE @count INT , @i INT =1, @name varchar(50);
SELECT @count= COUNT(*) FROM Persons;

WHILE @i <= @count
BEGIN 
  SELECT @name = [FirstName] FROM Persons Where personId=@i;
  IF (@i % 2) = 0
    PRINT CONCAT(@i, ' ',@name);
  SET @i = @i+1;
END