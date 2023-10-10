use  Sit375DB

--CREATE DATABASE SandeepTestDB
use SandeepTestDB

create table [User](
	UserId int Primary key identity(1,1),
	UserName varchar(250),
	UserEmail varchar(250),
	UserContact varchar(50),
	UserPassword varchar(50)
)


Insert Into [User](UserName,UserEmail,UserContact,UserPassword) Values('Sandeep','sandeep@gmail.com','1111111111','Sit@321#');

Select * from [User]


create proc SP_AddEditUser
(
	@UserId int,
	@UserName varchar(250),
	@UserEmail varchar(250),
	@UserContact varchar(50),
	@UserPassword varchar(50)
)
as
begin
	if(@UserId is null)
		begin
			begin try
				begin tran
					insert into [User]
					values(@UserName,@UserEmail,@UserContact,@UserPassword)
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
	else
		begin
			begin try
				begin tran
					update [User]
					set UserName=@UserName,UserEmail=@UserEmail,UserContact=@UserContact,UserPassword=@UserPassword
					where UserId=@UserId
				commit tran
			end try
			begin catch
				rollback tran
				print ERROR_MESSAGE()
			end catch
		end
end



create table CouponCodeMaster
(
	CouponId int primary key identity(1,1),
	Code varchar(250),
	Type varchar(100),
	FlatAmount int,
	Percentage int,
	Expirydate date,
	UsageLimit int,
	IsActive bit
)

insert into CouponCodeMaster
values('10-OFF','Percentage',0,10,'2024-01-01',10,1)

insert into CouponCodeMaster
values('100-FLAT','Flat',100,0,'2024-01-01',10,1)

insert into CouponCodeMaster
values('15-OFF','Percentage',0,15,'2024-01-01',5,1)

insert into CouponCodeMaster
values('150-FLAT','Flat',150,0,'2024-01-01',5,1)


select * from CouponCodeMaster


create table ItemMaster
(
  ItemId int primary key identity(1,1),
  ItemName varchar(250),
  ItemAmount decimal(10,2)
)


insert into ItemMaster
values('Pizza',200)

insert into ItemMaster
values('Vada Pav',60)

insert into ItemMaster
values('Burger',150)

select * from ItemMaster


create proc SP_GetAllItems
as
begin
	select * from ItemMaster
end


create proc SP_GetAllCoupons
as
begin
	select * from CouponCodeMaster
end


create table Orders(
	OrderId int primary key identity(1,1),
	TotalItems int,
	TotalAmount decimal(15,2),
	Cgst decimal(10,2),
	Sgst decimal(10,2),
	PaybleAmount decimal(25,2),
	NetPaybleAmount decimal(25,2),
	PromoCode varchar(250),
	OrderDate date default CURRENT_TIMESTAMP,
	UserId int foreign key references [User](UserId)
)


create table ItemDetails(
	ItemId int primary key identity(1,1),
	ItemName varchar(250),
	ItemQty int,
	ItemAmount decimal(12,2),
	OrderId int foreign key references Orders(OrderId)
)


Create proc SP_CreateOrder
(
	@TotalItems int,
	@TotalAmount decimal(15,2),
	@Cgst decimal(10,2),
	@Sgst decimal(10,2),
	@PaybleAmount decimal(25,2),
	@NetPaybleAmount decimal(25,2),
	@PromoCode varchar(250),
	@UserId int
)
as
begin
	begin try
		begin tran
			declare @OrderId int
			insert into Orders
			values(@TotalItems,@TotalAmount,@Cgst,@Sgst,@PaybleAmount,@NetPaybleAmount,@PromoCode,CURRENT_TIMESTAMP,@UserId)
			set @OrderId = SCOPE_IDENTITY()
		commit tran
			SELECT @OrderId
	end try
	begin catch
		rollback tran
		print error_message()
	end catch
end


exec SP_CreateOrder 2,34,34,34,34,9,'kjdksjk',1;

select * from orders

create proc SP_CreateItemDetail
(
	@ItemName varchar(250),
	@ItemQty int,
	@ItemAmount decimal(12,2),
	@OrderId int
)
as
begin
	begin try
		begin tran
			insert into ItemDetails
			values(@ItemName,@ItemQty,@ItemAmount,@OrderId)
		commit tran
	end try
	begin catch
		rollback tran
		print error_message()
	end catch
end



select * from orders
select * from ItemDetails

