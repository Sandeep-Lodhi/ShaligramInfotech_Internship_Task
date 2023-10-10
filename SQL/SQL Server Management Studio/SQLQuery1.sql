use SandeepMVC

select * from INFORMATION_SCHEMA.TABLES

select * from  City

insert into city values('Jammu',15)

CREATE TABLE Hobbies
(
id int not null primary key IDENTITY(1,1),
Hobby varchar(50) not null
);

insert into Hobbies(Hobby) values
('Singing'),
('Listing Musing'),
('shopping'),
('Traveling'),
('Hiking'),
('Penting'),
('Drawing'),
('Coocing'),
('Playing Cricket'),
('Dancing'),
('Boking'),
('Cycling');

select * from Hobbies
select * from Student

CREATE TABLE Student(id int not null primary key identity(1,1),name varchar(100),hobbies varchar(200));