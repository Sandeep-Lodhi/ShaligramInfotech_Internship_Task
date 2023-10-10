---SCOPE IDENTITY 
Scope identity ka use last table ke intry id check karne ke liye hota h.

--EXAMPLE 
ALTER proc [dbo].[sp_InsertIntoTreatment]
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
-----------------------------------------
--CROSS APPLY 
--cross apply ka use table ke row ka data multiple columns mai seprate karne ke liye hota h 
SELECT * FROM UsersT U
cross apply
(select value from string_split('1,2,3',',')) P
------------
--EXAMPLE
SELECT * FROM OrdersT U
cross apply 
(select value from string_split('1,2,3,4',',')) P


