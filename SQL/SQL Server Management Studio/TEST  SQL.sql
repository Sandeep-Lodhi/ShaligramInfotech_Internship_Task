CREATE DATABASE SandeepLodhi_SIT363

USE SandeepLodhi_SIT363
--TABLE : Users 
CREATE TABLE Users(
Id int NOT NULL primary key identity(1,1),
FirstName VARCHAR(50) NOT NULL, 
LastName VARCHAR(50) NOT NULL, 
Email varchar(50) UNIQUE,
Password varchar(10) check(len(Password)>=8 AND len(Password)<=10),
UserTypedid int Foreign key REFERENCES UserType(Id),
Address varchar(150) DEFAULT NULL,
MobileNo int NOT NULL,
CountryId INT Foreign key references Country(Id),
stateId int FOREIGN KEY REFERENCES States(Id),
CityId int FOREIGN KEY REFERENCES City(Id)
);

--TABLE : UserType 
CREATE TABLE UserType(Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
UserTypeName varchar(50) NOT NULL);

--TABLE : Country 
CREATE TABLE Country(Id int NOT NULL PRIMARY KEY IDENTITY(1,1), CountryName VARCHAR(50) NOT NULL);
--TABLE : Diagnosis 
CREATE TABLE Diagnosis(Id INT NOT NULL PRIMARY KEY IDENTITY(1,1) ,DiagnosisDetails varchar(100) NOT NULL);
--DROP TABLE Diagnosis
--TABLE : States 
CREATE TABLE States(Id INT NOT NULL Primary key IDENTITY(1,1), StateName VARCHAR(50) NOT NULL,CountryId int FOREIGN KEY REFERENCES Country(Id));
--TABLE : Medicine 
CREATE TABLE Medicine(Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),MedicineName VARCHAR(100) NOT NULL,DiagnosisId INT FOREIGN KEY REFERENCES Diagnosis(Id));
--TABLE : TreatmentDetails 
CREATE TABLE TreatmentDetails(
Id int NOT NULL primary key identity(1,1),
PatientId INT FOREIGN KEY REFERENCES UserType(Id) ,
DoctorId INT FOREIGN KEY REFERENCES UserType(Id) ,
NurseId INT FOREIGN KEY REFERENCES UserType(Id),
Diagnosis int FOREIGN KEY REFERENCES Diagnosis(Id),
Prescription INT FOREIGN KEY REFERENCES Medicine(Id),TreatmentFee DECIMAL NOT NULL,
DOT DATE ,
instructions VARCHAR(300) DEFAULT NULL
);

--TABLE : City 
CREATE TABLE City(Id int NOT NULL PRIMARY KEY IDENTITY(1,1),CityName varchar(50) NOT NULL,StateId INT FOREIGN KEY REFERENCES States(Id));


--Q1) EVERY INSERT statement shoud be by store procesure.. 

CREATE PROC sp_InsertUsers

 (@FirstName varchar(50),@LastName varchar(50),@Email varchar(50),@Password varchar(10),@UserTypedid int,@Address varchar(150),@MobileNo int,@CountryId int,@stateId int,@CityId int)
AS
BEGIN
  INSERT INTO Users(FirstName,LastName,Email,Password,UserTypedid,Address,MobileNo,CountryId,stateId,CityId) VALUES (@FirstName,@LastName,@Email,@Password,@UserTypedid,@Address,@MobileNo,@CountryId,@stateId,@CityId)
END

drop proc sp_InsertUsers
 
EXEC sp_InsertUsers 'Krunal','Dhote','krunal@gmail.com','krunal12',1,'Amravati',1200010000,1,1,1;

EXEC sp_InsertUsers 'Raj','Shah','raj@gmail.com','rahShah12',2,'Ahamdabad',1200011000,2,2,2;
EXEC sp_InsertUsers 'Rohit','Pandit','rohit@gmail.com','Rohit@321',3,'Delhi',1100011000,3,3,3
EXEC sp_InsertUsers 'Sandeep','Lodhi','sandeep@gmail.com','sandeep12',1,'Madhya Pradesh',1900011000,4,4,4
EXEC sp_InsertUsers 'Kavita','Burse','burse@gmail.com','birse125',3,'california',1210011000,5,5,5


CREATE PROC sp_InsertUserType
(@UserTypeName varchar(50))
AS
BEGIN
 INSERT INTO UserType(UserTypeName) VALUES(@UserTypeName);
END

EXEC sp_InsertUserType 'Doctor'
EXEC sp_InsertUserType 'Patient'
EXEC sp_InsertUserType 'Nurse'

CREATE PROC sp_InsertCountry
(@CountryName VARCHAR(50) )
AS
BEGIN
 INSERT INTO  Country(CountryName) VALUES(@CountryName);
END

EXEC sp_InsertCountry 'India'
EXEC sp_InsertCountry 'China'
EXEC sp_InsertCountry 'USA'
EXEC sp_InsertCountry 'Rusia'
EXEC sp_InsertCountry 'India'

CREATE PROC sp_InsertDiagnosis
 (@DiagnosisDetails varchar(50))
AS
BEGIN
  INSERT INTO Diagnosis(DiagnosisDetails) VALUES(@DiagnosisDetails)
END

EXEC sp_InsertDiagnosis 'Fever'
EXEC sp_InsertDiagnosis 'Cold'
EXEC sp_InsertDiagnosis 'Headache'
EXEC sp_InsertDiagnosis 'Stomatchache'
EXEC sp_InsertDiagnosis 'Vomit'

CREATE PROC sp_InsertStates
 (@StateName varchar(50),@CountryId int)
AS
BEGIN
INSERT INTO States(StateName,CountryId) VALUES(@StateName,@CountryId)
END

EXEC sp_InsertStates 'Gujrat',1
EXEC sp_InsertStates 'Buhan',2
EXEC sp_InsertStates 'California',3
EXEC sp_InsertStates 'Amur Region',4
EXEC sp_InsertStates 'MP',5
 
 CREATE PROC sp_InsertMedicine
 (@MedicineName varchar(50),@DiagnosisId int)
 AS
 BEGIN
 INSERT INTO Medicine(MedicineName,DiagnosisId) VALUES(@MedicineName,@DiagnosisId)
 END

 EXEC sp_InsertMedicine 'Dolo600',1
 EXEC sp_InsertMedicine 'Levocetirizine',2
 EXEC sp_InsertMedicine 'Panadol',3
 EXEC sp_InsertMedicine 'Liquiprin',4
 EXEC sp_InsertMedicine 'Paracetamol',5

 CREATE PROC sp_InsertTreatmentDetails
 (@PatientId int,@DoctorId int,@NurseId int,@Diagnosis int,@Prescription int,@TreatmentFee DECIMAL,@DOT DATE,@instructions VARCHAR(300))
 AS
 BEGIN
  INSERT INTO TreatmentDetails(PatientId,DoctorId,NurseId,Diagnosis,Prescription,TreatmentFee,DOT,instructions) VALUES(@PatientId,@DoctorId,@NurseId,@Diagnosis,@Prescription,@TreatmentFee,@DOT,@instructions)
 END

 EXEC sp_InsertTreatmentDetails 2,1,3,1,1,1200,'2023-04-18','Bad Rest';
 EXEC sp_InsertTreatmentDetails 2,1,3,2,2,1500,'2023-04-15',' Take Medicine After Denner';
 EXEC sp_InsertTreatmentDetails 2,1,3,3,3,1800,'2023-04-19','Take Medicine with Milk';
 EXEC sp_InsertTreatmentDetails 2,1,3,4,4,2000,'2023-04-16','Bad Rest';
 EXEC sp_InsertTreatmentDetails 2,1,3,5,5,1000,'2023-04-17','Do Excesice Daily';

 CREATE PROC sp_InsertCity	
 (@CityName varchar(50),@StateId int)
 AS
 BEGIN
 INSERT INTO City(CityName,StateId) VAlUES(@CityName,@StateId)
 END


 EXEC sp_InsertCity 'Ahamdabad',1
 EXEC sp_InsertCity 'Valington',2
 EXEC sp_InsertCity 'Plazza',3
 EXEC sp_InsertCity 'Thai',4
 EXEC sp_InsertCity 'Bhopal',5

 Truncate table Users
 Truncate  table UserType

SELECT * FROM Users
SELECT * FROM UserType
SELECT * FROM Country
SELECT * FROM Diagnosis
SELECT * FROM States
SELECT * FROM Medicine
SELECT * FROM TreatmentDetails
SELECT * FROM City

--Q2) Make a optional parametrized stored proceure for retrive  all the doctors usertype (if user given a paricular doctotr)

 
 CREATE or ALTER PROC sp_InsertDoctors
 @Id int
 AS
 BEGIN
 IF (@Id is NULL)
BEGIN 
 SELECT UserType.Id, CONCAT('Dr.','',Users.FirstName,'',Users.LastName) As DoctorName,CONCAT(Country.CountryName,',',States.StateName,',',City.CityName) AS Address,MobileNo 
  From UserType INNER JOIN Users ON UserType.Id = Users.Id INNER JOIN Country ON UserType.Id= Country.Id INNER JOIN States ON UserType.Id =States.Id INNER JOIN City ON UserType.Id = City.Id;
END
ELSE 
BEGIN
      SELECT UserType.Id, CONCAT('Dr.','',Users.FirstName,'',Users.LastName) As DoctorName,CONCAT(Country.CountryName,',',States.StateName,',',City.CityName) AS Address,MobileNo 
  From UserType INNER JOIN Users ON UserType.Id = Users.Id INNER JOIN Country ON UserType.Id= Country.Id INNER JOIN States ON UserType.Id =States.Id INNER JOIN City ON UserType.Id = City.Id Where UserType.Id =@Id;
END
END


 EXEC sp_InsertDoctors  null
 EXEC sp_InsertDoctors 1

 --Q3) Make A function That Will return medicine as per Diagnosis...

 CREATE OR ALTER FUNCTION DiagnosisFunc(@Diagnosis Varchar(30))
RETURNS TABLE 

AS
RETURN SELECT Medicine.MedicineName FROM Diagnosis INNER JOIN  Medicine ON Diagnosis.Id = Medicine.Id Where Diagnosis.DiagnosisDetails =  @Diagnosis;

SELECT * from DiagnosisFunc('Headache') 
--===========================================================================
--Q4) 

CREATE PROC sp_last
AS
BEGIN 
DECLARE @pasentName varchar(50)
SET  @pasentName = (SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Pasent Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 2)


DECLARE @doctorName varchar(50)

SET  @doctorName= (SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Doctor Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 1)

DECLARE @nurseName varchar(50)
SET @nurseName = (SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Nurse Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 3)

DECLARE @Medicine  varchar(50)
SET @Medicine = dbo.DiagnosisFunc(Diagnosis.DiagnosisDetails)

DECLARE  

DECLARE DOT DATE
SET DOT = (SELECT TreatmentDetails.DOT FROM TreatmentDetails)

DECLARE @PatientAddress VARCHAR(225)
SET @PatientAddress = (SELECT CONCAT(Country.CountryName,',',States.StateName,',',City.CityName) AS [Patient Address] FROM Country
  INNER JOIN States ON Country.Id = States.CountryId
  INNER JOIN City ON States.Id = City.StateId)

DECLARE 
CONCAT(Country.CountryName,',',States.StateName,',',City.CityName) AS [Patient Address],
Users.MobileNo,
CONCAT('Rs',' ',TreatmentDetails.TreatmentFee) AS TreatmentFee FROM Users

END





SELECT * FROM Users
SELECT * FROM UserType
SELECT * FROM Country
SELECT * FROM Diagnosis
SELECT * FROM States
SELECT * FROM Medicine
SELECT * FROM TreatmentDetails
SELECT * FROM City

--===========================================================================
--1_Pasent Name 

SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Pasent Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 2;           --UserTypeName ='Patient';


-- 2_DoctorName
SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Doctor Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 1; 


-- 3_Nurse Name
SELECT CONCAT(Users.FirstName,' ',Users.LastName) AS [Nurse Name] FROM Users 
INNER JOIN UsersType ON Users.UserTypedid = UsersType.UserTypeId 
WHERE UsersType.UserTypeId = 3; --UserTypeName ='Nurse';


--Medicine
 dbo.DiagnosisFunc(Diagnosis.DiagnosisDetails)

 --DOT
  TreatmentDetails.DOT

  --Patient Address
  SELECT CONCAT(Country.CountryName,',',States.StateName,',',City.CityName) AS [Patient Address] FROM Country
  INNER JOIN States ON Country.Id = States.CountryId
  INNER JOIN City ON States.Id = City.StateId
  
--Mobile NO 
SELECT Users.MobileNo From Users

--Treatment Fee
SELECT TreatmentDetails.TreatmentFee From TreatmentDetails


SELECT * FROM Users
SELECT * FROM UserType
SELECT * FROM Country
SELECT * FROM Diagnosis
SELECT * FROM States
SELECT * FROM Medicine
SELECT * FROM TreatmentDetails
SELECT * FROM City

--******************************************************************************************************
--Bhavya Code 4 question 
create proc sp_InsertIntoTreatment
(
@PatientId int,
@DocterId int,
@NurseId int,
@Diagnosis varchar(255),
@Prescription varchar(255),
@TreatmentFee decimal(7,2),
@DOT datetime,
@Instruction nvarchar(max),
@TreatmentId int =null out
)
as
begin
	insert into TreatmentDetails values(@PatientId,@DocterId,@NurseId,@Diagnosis,@Prescription,@TreatmentFee,@DOT,@Instruction); 
	set @TreatmentId = scope_identity();
end

exec sp_InsertIntoTreatment 2,5,4,'1','1',500,'2023-03-03','Get Well Soon'