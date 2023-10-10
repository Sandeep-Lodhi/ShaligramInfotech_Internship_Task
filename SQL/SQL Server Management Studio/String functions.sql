use SandeepLodhi_SIT363

SELECT ASCII('a')
SELECT ASCII('A') as letter

--CHAR :Convert ascii value to a character

SELECT CHAR(97)
SELECT CHAR(122)

--CHARINDEX : search for a substring inside a sring form a starting form a specified
--location and return the ...
--Syntax charindex (expressiontoFind,expressionto search)

SELECT CHARINDEX('ma','lotusamaze')

--CONCAT : join two or more string into one string

SELECT CONCAT('Sandeep','Lodhi') as NAme

--CONCAT_WS : concatenate multiple string with a seprator into a single string 
select CONCAT_WS('_','Lotus','amaze','Solutions')

 --LEFT: Extract a given a number of character from a character string string starting form the left
 --Syntax: LEFT(character_expression,integer_expression)
 --RIGHT:Extract a given a number of character form a character string starting from the right 
 --Syntax Right (character_expression,integer_expression)

 SELECT LEFT('Sandeep',4)
  SELECT RIGHT('Sandeep',4)

  --LEN : return a number of characters of a charactes of a character stiring
  --LOWER : Convert a string to lower
  --UPPER : convert a string to upper 
  SELECT LEN('Krunal is a good boy');
  SELECT UPPER('Krunal is a good boy');
  SELECT LOWER('Krunal is a good boy');


  --LTRIM : Return a new string form a specified after removeing all leading blanks
  --RTRIM : Return a new string from a specified string after removing all trailing blanks 
   
   SELECT CONCAT('Lotusamze    ','        Solution')
  SELECT CONCAT(RTRIM('Lotusamze    '),LTRIM('        Solution'))

  --PATINDEX : RETURN the ssring position of the first occurence of a pattern in a string.
  --SYNTAX : PATINDEX ('%PAttern%','Expression')

  SELECT PATINDEX('%ama%','Lotusamaze')
  SELECT PATINDEX('%ama%','amaLotusamaze')
  SELECT PATINDEX('%ama%','Lotusamazeama')


  --REPLACE :
  --SYNTAX : REPLACE(string_expression,string_pattern,string_replacement)

  SELECT REPLACE('Lotusamaxefdsdf123','123','IT Solution');
  --STUFF :
  --Syntax:stuff(character_expression,start,length,replacewith_expression)
  SELECT STUFF('Losandeep123',3,4,'IT Solution')
  
  --INTEGRITY 
