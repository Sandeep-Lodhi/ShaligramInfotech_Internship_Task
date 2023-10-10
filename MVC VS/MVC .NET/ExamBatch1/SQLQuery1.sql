Use KrunalDhote351

create table CoupenCodeMaster(
	CoupenId int not null primary key identity(1,1),
	Code varchar(50) not null unique,
	Type bit not null,
	FlatAmount int,
	PercentageAmount int,
	Expiry Date not null,
	Limit int not null,
	IsActive Bit not null
)
Insert Into CoupenCodeMaster Values('FLAT100',0,100,0,'10-10-2023',10,1),('10OFF',1,0,10,'06-23-2023',8,1),('20OFF',1,0,20,'06-19-2023',3,1),('FLAT200',0,200,0,'10-10-2023',0,1),('30OFF',1,0,30,'07-29-2023',4,0)

create table ItemMaster(
	ItemId int identity(1,1) not null primary key,
	Item varchar(100),
	Amount int not null
)
Insert Into ItemMaster Values('Pizza',300),('Burger',200),('VadaPao',150),('Manchurian',120),('Samosa',40),('Fries', 60),
('Soda', 20);


create table CustomerMaster(
	CustId int identity(1,1) not null primary key,
	Name varchar(200) not null,
	Email varchar(100) unique not null,
	Password varchar(20) not null,
)

Create Table OrdersMaster(
	OrderId int not null primary key identity(1,1),
	OrderDate Date not null,
	Amount decimal not null,
	AfterGST decimal not null,
	PromoCode varchar(20),
	PayingAmount decimal not null,
	CGST decimal not null,
	SGST decimal not null,
	CustId int references CustomerMaster(CUstId)
)

insert into OrdersMaster values('12-13-2022',800,880,'FLAT100',780,40,40,2),('02-13-2023',800,880,'FLAT100',780,40,40,2)

create or alter proc sp_GetOrdersByDate
@id int,
@from date=null,
@to date=null
as
begin
	if(@from is null and @to is null)
	begin
		select * from OrdersMaster where CustId=@id
	end
	else if(@from is null)
	begin
		select * from OrdersMaster where OrderDate<@to and CustId=@id;
	end
	else if(@to is null)
	begin
		select * from OrdersMaster where OrderDate>=@from and CustId=@id;
	end
	else
		select * from OrdersMaster where OrderDate>=@from and OrderDate<@to and CustId=@id;
end

exec sp_GetOrdersByDate 2
exec sp_GetOrdersByDate 2,'12-13-2022'
exec sp_GetOrdersByDate 2,'','12-30-2022'
exec sp_GetOrdersByDate 2,'12-17-2022','12-12-2023'



		create or alter proc kunalDemo
		@id int,
		@from date =null,
		@to date = null
		as
		begin
		select * from OrdersMaster where CustId=@id
		and (@from is null Or OrderDate>=@from)
		and (@to is null Or OrderDate<=@to);
		end

		exec kunalDemo 2,null,null