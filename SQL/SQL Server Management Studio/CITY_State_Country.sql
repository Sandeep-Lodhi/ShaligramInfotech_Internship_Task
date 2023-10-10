use SandeepMVC

create table country
(
Cid int not null identity(1,1) primary key,
Cname varchar(100),
);

INSERT INTO country(Cname) values ('India'),('USA'),('Ausralia');
select * FROM country


create table State
(
Sid int not null identity(1,1) primary key,
Sname varchar(100),
Cid int
);

INSERT INTO State(Sname,Cid) 
values
('Telangna',1),
('Karnataka',1),
('Amaravathi',1),
('Tamilnadu',1),
('California',2),
('Texas',2),
('Queensland',3),
('Victoria',3),
('Western Australia',3);

select * From State;




create table City
(
Cityid int not null identity(1,1) primary key,
Cityname varchar(100),
Sid int
);

INSERT INTO City(Cityname,Sid) values
('Heyderabad',1),
('Banglore',2),
('Amravathi',3),
('Chennai',4),
('Sacremento',5),
('Austin',6),
('Trenton',7),
('Brisbane',8),
('Melbourne',9),
('Perth',10);

select * from City

