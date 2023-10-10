use KrunalDhote351

create Table Department(
	Id int primary key not null identity(1,1),
	Name varchar(100) not null unique
)
Insert Into Department Values ('CSE'),('IT Engineering'),('Civil'),('Electrical Engineering'),('Architecthure Engineering'),('AIDS Engineering'),('Mechanical Engineering'),('Electronics Engineering'),('Instrumentation Engineering'),('Petrolium Engineering'),('Chemical Engineering'),('Biomedical Engineering'),('Aerospace Engineering'),('Environmental Engineering'),('Nuclear Engineering'),('MCA'),('MBA'),('MBBS'),('BAMS'),('BHMS'),('Pharmacy'),('Pharm-D'),('BSc Agriculture'),('BSc Plane'),('BSc Math'),('BSc Biology'),('BSc Electronics'),('BSc CS'),('BA'),('MA'),('B Com.'),('M Com.')

create table Student(
	Id int identity(1,1) not null primary key,
	FirstName varchar(100) not null,
	LastName Varchar(100) not null,
	Contact char(10) not null check(len(Contact)=10),
	DateOfBirth Date not null,
	Gender varchar(20) not null,
	Email Varchar(100) unique not null,
	Password varchar(20) check(len(Password)>6),
	Address varchar(255) not null,
	DepartmentId int Foreign Key References Department(Id),
	CountryId int Foreign Key References Country(id),
	StateId int Foreign Key References State(id),
	CityId int Foreign Key References City(id)
)


