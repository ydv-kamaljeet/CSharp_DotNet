--Stored Procedure syntax
GO
use TestDB
GO

-- =============================================
-- Author:		Kamaljeet
-- Create date: 22-01-2026
-- Description:	Procedure to retrieve Order details by OrderId
-- =============================================
alter procedure myPractice
    --optional or parameters
    @OrderId int
as begin
    select *
    from Orders
    where OrderId = @OrderId
end;
exec myPractice 5001
go


-- =============================================
-- Description:	Procedure to retrieve customer details by their name and city
-- =============================================
alter procedure SP_GetCustomerByNameAndCity
    --optional or parameters
    @FullName varchar(100),
    @City varchar(50)
as begin
    select *
    from Customers
    where FullName = @FullName and City = @City
end;
exec SP_GetCustomerByNameAndCity 'Gopi Suresh', 'Coimbatore'
go
-- Go sepearates the queries 



-- =============================================
-- Description:	Procedure to Update User details by their name
-- =============================================
alter PROCEDURE SP_UpdateNameAndAgeByName
    @Name char(50)
as BEGIN
    update TestTbl 
set Name='Kamal',Age=26 
where Name=@Name
end;
exec SP_UpdateNameAndAgeByName 'Rahu'
go


-- =============================================
-- Description:	Procedure to insert User details in TestTbl
-- =============================================
create PROCEDURE  SP_InsertDataInTestTbl
    @Name char(50),
    @Age INT
as
begin
    INSERT INTO TestTbl
        (Name, Age)
    VALUES
        (@Name, @Age)
    --now to retrive the data  : check whether data is inserted or not
    select *
    from TestTbl
END

go

-- =============================================
-- Description:	Procedure to create User Table
-- =============================================
create or alter procedure SP_CreateUserTable
as
begin
    CREATE TABLE Users
    (
        UserId INT NOT NULL PRIMARY KEY,
        -- Manual PK
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        Email NVARCHAR(255) NOT NULL UNIQUE,
        PhoneNumber NVARCHAR(15)
    );
end
exec SP_CreateUserTable
go


-- =============================================
-- Description:	Procedure to Insert record in User Table
-- =============================================
create or alter PROCEDURE SP_InsertIntoUserTable
    @UserId int ,
    @FullName varchar(100),
    @LastName varchar(100),
    @Email varchar(510),
    @PhoneNumber varchar(30)
as
begin
    INSERT INTO Users
        (UserId,FirstName, LastName, Email, PhoneNumber)
    VALUES
        (@UserId, @FullName, @LastName, @Email, @PhoneNumber)
end
exec SP_InsertIntoUserTable '109','Rohan','singh','asfinds@gamil.com','2342123141'

go

select * from () t where t.Age > m.age; 

