DECLARE @i INT = 10, @j INT = 1;

 WHILE @i <= 30
	BEGIN
		PRINT CONCAT ('i = ', @i); 
  		
		WHILE @j <=3
			BEGIN
				PRINT CONCAT ('j = ', @j); 
				SET @j = @j + 1;
	  		END
		SET @i = @i + 10;
	END;