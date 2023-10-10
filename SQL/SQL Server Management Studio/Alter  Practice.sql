
Create table studentTable(id int, name varchar(50));

SELECT * FROM studentTable

alter table studentTable 
ALTER TABLE studentTable ALTER COLUMN id int NOT NULL;

ALTER TABLE studentTable ADD PRIMARY KEY (id);

insert into studentTable (id, name) values(2,'Sandeep');

UPDATE studentTable SET name= 'Raj' WHERE id= 2;

alter table class add primary key (section);

drop table  studentTable

---------------------------------------------

SELECT COLUMN NAME FROM (((TABLENAME1 right join TableName2  on table2.column = table1.column)
                                      right join tableName3 On table3.columnname = table1.column )
                                      right join table4 on table2.column = table1.column )


ALTER TABLE TABLENAME ADD COLUMN COLUMNNAME DATATYPE
ALTER TABLE TABLENAME DROP COLUMN COLUMNNAME 
ALTER TABLE TABLENAME RENAME COLUMN  OLD TO NEW 
ALTER TABLE table_name MODIFY COLUMN column_name datatype;

 
