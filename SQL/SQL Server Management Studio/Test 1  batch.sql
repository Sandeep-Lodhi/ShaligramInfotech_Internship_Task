use SandeepLodhi_SIT363;
Create Table Customer
( 
  Id int not null,
  Name varchar(50),
  UserName varchar(50) unique,
  password varchar(50),
  Email varchar(50) unique,
  DOB date,
  Address varchar(150),
  ContactNo int Unique,
 );


Create Table Salesman 
(
 Id int,
 Name varchar(50),
 UserName varchar(50), 
 Password varchar(50),
 Email varchar(50),
 DOB date,
 Address varchar(150),
 ContactNo int
);

Create Table Category
(
Id int,
Name varchar(50)
);

Create Table Items
(
Id int,
Name varchar(50), 
Category varchar(50),
Rate DEcimal,
DOM date, 
DOE date
);

Create Table ModeOfPayment
(
Id int,
Name varchar(50)
);

Create Table Orders
(
 Id int,
 OrderNo int Unique,
 Customer varchar(50),
 OrderQty int,
 BillAmount decimal,
 DOD DATE,
 Salesman varchar(50),
 DeliveryAddress varchar(150),
 City varchar(50),
 ContactNo int,
 MOB varchar(50),
 OrderStatus BIT,
);


Create Table OrderDetails
(
 Id int,
 OrderId int,
 ItemId int,
 OrderQty int,
 OrderAmount decimal
 );

 --1. After Creating Table , need to update All table with Primary Key , Clustor Key  and Add Identity 
 ALTER TABLE Customer DROP COLUMN Id ;
 ALTER TABLE Customer ADD  Id int primary key Identity(1,1);

 ALTER TABLE Salesman DROP column Id;
 ALTER TABLE Salesman ADD Id int Primary key Identity(1,1);

 ALTER TABLE Category DROP COLUMN Id;
 ALTER TABLE Category ADD Id int Primary key Identity(1,1);

  ALTER TABLE Items DROP COLUMN Id;
  ALTER TABLE Items ADD Id int Primary key Identity(1,1);

   ALTER TABLE ModeOfPayment DROP COLUMN Id;
   ALTER TABLE ModeOfPayment ADD Id int Primary key Identity(1,1);

   ALTER TABLE Orders DROP COLUMN Id;
   ALTER TABLE Orders ADD Id int Primary key Identity(1,1);

   ALTER TABLE OrderDetails DROP COLUMN Id;
   ALTER TABLE OrderDetails ADD Id int Primary key Identity(1,1);

   --2. Create a Parameterized Store Procedure to Insert/Update Data in each of tables listed above. (If Primary key of that table is passed then Update else Insert)
	--E.g : SP_AddEditCustomer (By using this procedure I will be able to insert or update data)
  
  CREATE PROC SP_AddEditCustomer 
   (@Name varchar(50),@UserName varchar(50),@password VARCHAR(50),@Email varchar(50),@DOB date,@Address varchar(150),@ContactNo int)
  AS
  BEGIN 
      INSERT INTO Customer(Name,UserName,password,Email,DOB,Address,ContactNo) VALUES (@Name,@UserName,@password,@Email,@DOB,@Address,@ContactNo);
  END 

  EXEC SP_AddEditCustomer 'Sandeep','Sandeep@321','San@321#','sandeep@gmail.com','2021-04-13','Bhopal MP','1234567867';


  
    
	CREATE PROC SP_AddInsertSalesman
	@Name varchar(50),
	@UserName varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@DOB DATE,
	@Address varchar(150),
	@ContactNo int
  AS
  BEGIN 
    INSERT INTO Salesman(Name,UserName,Password,Email,DOB,Address,ContactNo) values ( @Name,@UserName,@Password,@Email,@DOB,@Address,@ContactNo)
  END 

  EXEC SP_AddInsertSalesman 'Sandeep','Sandeep@321','Sandi@321#','Sandeep@gmail.com','2001-04-13','Bhopal MP',435243;



    CREATE PROC SP_AddInsertCategory 
	   @Name varchar(50)
  AS
  BEGIN 
      INSERT INTO Category(Name) VALUES(@Name);
  END 

  EXEC SP_AddInsertCategory 'Sandeep';




    CREATE PROC SP_AddInsertItems 
	 (@Name varchar(50),@Category varchar(50),@Rate DECIMAL,@DOM date,@DOE DATE)
  AS
  BEGIN 
      INSERT INTO Items( Name,Category,Rate,DOM,DOE) VALUES(@Name,@Category,@Rate,@DOM,@DOE)
  END 

  EXEC SP_AddInsertItems 'Mobile','Electronics',12000,'2012-05-23',NULL



    CREATE PROC SP_AddEditModeOfPayment 
	  @Name	VARCHAR(50)
  AS
  BEGIN 
     INSERT INTO ModeOfPayment(Name) VALUES (@Name)
  END 

  EXEC SP_AddEditModeOfPayment 'Online';



    CREATE PROC SP_AddInsertOrders 
	 (@OrderNo int,@Customer varchar(50),@OrderQty int,@BillAmount decimal,@DOD date,@Salesman varchar(50),@DeliveryAddress varchar(150),@City varchar(50),@ContactNo int,@MOB varchar(50),@OrderStatus BIT)

  AS
  BEGIN 
     INSERT INTO Orders(OrderNo,Customer,OrderQty,BillAmount,DOD,Salesman,DeliveryAddress,City,ContactNo,MOB,OrderStatus) VALUES (@OrderNo,@Customer,@OrderQty,@BillAmount,@DOD,@Salesman,@DeliveryAddress,@City,@ContactNo,@MOB,@OrderStatus)
  END 

  EXEC SP_AddInsertOrders 101,'Raj',2,12000,'2023-04-19','Krunal','Ghandhi Nagar','Ahamdabad',62382383,'Online',0;




    CREATE PROC SP_AddInsertOrderDetails 
	 (@OrderId int,@ItemId int,@OrderQty int,@OrderAmount decimal)
  AS
  BEGIN 
      INSERT INTO OrderDetails(OrderId,ItemId,OrderQty,OrderAmount) VALUES( @OrderId,@ItemId,@OrderQty,@OrderAmount);
  END 

  EXEC SP_AddInsertOrderDetails 101,30001,2,12000

 SELECT * FROM Customer
 SELECT * FROM Salesman
 SELECT * FROM Category
 SELECT * FROM Items
 SELECT * FROM ModeOfPayment
 SELECT * FROM Orders
 SELECT * FROM OrderDetails


 CREATE PROC SP_AddEditCustomers
 (@Name varchar(50),
 @UserName varchar(50),
 @password VARCHAR(50),
 @Email varchar(50),
 @DOB date,
 @Address varchar(150),
 @ContactNo int,
 @Id int)
 AS

 IF @Id = (SELECT Id FROM Customer WHERE  Id = @Id)

 BEGIN
       UPDATE Customer
            SET    Name = @Name,
                   UserName = @UserName,
                   password = @password,
                   Email = @Email,
				   DOB=@DOB,
				   Address=@Address,
				   ContactNo=@ContactNo
             WHERE  Id = @Id
END
ELSE
  BEGIN 
   INSERT INTO Customer
	 (
	 Name,UserName
	 ,password,
	 Email,
	 DOB,
	 Address,
	 ContactNo
	 ) 
	 VALUES 
	 (@Name,
	 @UserName,
	 @password,
	 @Email,
	 @DOB,
	 @Address,
	 @ContactNo
	 );
 END


 EXEC SP_AddEditCustomers 'Krunal','Krunal@321','@San11','Krunal@gmail.com','2000-08-23','Amravati',43543545,2


