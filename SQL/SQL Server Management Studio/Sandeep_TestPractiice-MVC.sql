--use Sandeep_Phase3

use SandeepTestDB
CREATE TABLE Country
(
id int not null primary key identity(1,1),
CountryName varchar(100)
);

insert into Country(CountryName) values('India'),('America'),('pakistan');
select * from Country;

CREATE TABLE State
(
id int not null primary key  identity(1,1), 
StateName varchar(100),
Cid int  foreign key references Country(id)
);

Insert into State(StateName,Cid) values ('Madhya Praesh',1),('Uttar Praesh',1),('Gujrat',1);
Insert into State(StateName,Cid) values ('California',2),('Florida',2),('Georgia',2);
Insert into State(StateName,Cid) values ('lahore',3),('Karachi',3),('Multan',3);

select * from State
select * from Country

create table City
(
id int not null primary key identity(1,1),
CityName varchar(100),
Cid int foreign key references Country(id),
Sid int foreign  key references State(id)
)

Insert into City(CityName,Cid,Sid) values('Bhopal',1,1),('Ashok Nagar',1,1),('Datia',1,1);
Insert into City(CityName,Cid,Sid) values('Lalitpur',1,2),('Jhashi',1,2),('Lakhnow',1,2);
Insert into City(CityName,Cid,Sid) values('Ahamdabad',1,3),('Rajkot',1,3),('Shurat',1,3);

Insert into City(CityName,Cid,Sid) values('Los Angeles',2,4),('San Diego',2,4),('San Jose',2,4);
Insert into City(CityName,Cid,Sid) values('Jacksonville',2,5),('Miami',2,5),('Tampa',2,5);

Insert into City(CityName,Cid,Sid) values('Laha-pur',3,7),('Laha-Noor',3,7),('Laha-war',3,7);
Insert into City(CityName,Cid,Sid) values('jamsed',3,8),('Kiamari',3,7),('gulsan',3,8);



select * from City;
select * from State;
select * from Country;

CREATE TABLE Hobbies
(
id int not null primary key identity(1,1),
Hobby varchar(50) not null
);

insert into Hobbies(Hobby) values('Blogging'),('Arts'),('sport'),('Cricket'),('Cooking'),('Football'),('Basketball'),
('Photography'),('Shoemaking'),('Singing'),('Shopping'),('Skipping rope'),('Social media'),('Sketching');

select * from Hobbies



CREATE TABLE Gender
(
id int not null primary key identity(1,1), 
GName varchar(30) not null
)

insert into Gender (GName) values ('Male'),('female'),('Other');

select * from Gender

CREATE TABLE Registration
(
id int not null primary key identity(1,1),
FirstName varchar(100),
LastName  varchar(100),
Email varchar(50),
Password varchar(30),
DOB date,
Address varchar(200),
CountryId int foreign key references Country(id),
StateId int foreign key references State(id),
CityId int foreign key references City(id),
ProfilePic varchar(MAX),
AttachmentDoc varchar(MAX),
Gender  varchar(30),
Hobbies varchar(200),
);


select * from Registration
