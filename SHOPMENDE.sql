CREATE DATABASE SHOPMENDE
GO

USE SHOPMENDE
GO

-- CREATE TABLE CATEGORY
Create table Category
(
  Id int primary key identity,
  CatName nvarchar(50)
)
GO

Insert into Category values('Home')
Insert into Category values('Shirt')
Insert into Category values('Jacket - hoodie')
Insert into Category values('Tee')
Insert into Category values('Backpack - Bag')
Insert into Category values('Pants')
GO


-- CREATE TABLE PRODUCT
Create table Products
(
  ProId int Primary Key Identity(1,1),
  ProName nvarchar(50),
  ProImage nvarchar(100),
  AfterProImage nvarchar(100),
  ProPrice decimal(18,3),
  CatId int
)
GO

-- Add Foreign Key into Product Table Reference to the Category Table
Alter table Products add foreign key (CatId) references Category(Id)
GO

-- Insert Some Test data into Products Table

Insert into Products values(N'Polo Empty - Đen', N'anh1_1.png', N'anh1_2.png',320.000, 1)
Insert into Products values(N'Polo Empty - Trắng', N'anh2_1.png', N'anh2_2.png', 320.000, 1)
Insert into Products values(N'Fallen Angel Tee - Nâu', N'anh3_1.png', N'anh3_2.png', 320.000, 1)
Insert into Products values(N'Mende Studio Shirt', N'anh4_1.png', N'anh4_2.png', 320.000, 1)
Insert into Products values(N'Farley Shirt', N'anh5_1.png', N'anh5_2.png', 320.000, 1)
Insert into Products values(N'Back To School Tee', N'anh6_1.png', N'anh6_2.png', 320.000, 1)
Insert into Products values(N'M Signature Shirt', N'anh7_1.png', N'anh7_2.png', 320.000, 1)
Insert into Products values(N'Polo Silken - Trắng', N'anh8_1.png', N'anh8_2.png', 320.000, 1)
Insert into Products values(N'Silky Caro - Black', N'anh9_1.png', N'anh9_2.png', 320.000, 1)
Insert into Products values(N'Double Pocket - Xám', N'anh10_1.png', N'anh10_2.png', 320.000, 1)
Insert into Products values(N'Double Pocket - Trắng', N'anh11_1.png', N'anh11_2.png', 320.000, 1)
Insert into Products values(N'Titan Polo', N'anh12_1.png', N'anh12_2.png', 320.000, 1)

Insert into Products values(N'MND Bandana', N'shirt1_1.png', N'shirt1_2.png', 60.000, 2)
Insert into Products values(N'Mende Studio Shirt', N'shirt2_1.png', N'shirt2_2.png', 380.000, 2)
Insert into Products values(N'Farley shirt', N'shirt3_1.png', N'shirt3_2.png', 330.000, 2)
Insert into Products values(N'M Signature Shirt', N'shirt4_1.png', N'shirt4_2.png', 350.000, 2)
Insert into Products values(N'Polo Silken - Trắng', N'shirt5_1.png', N'shirt5_2.png', 385.000, 2)
Insert into Products values(N'Skilky Caro - Black', N'shirt6_1.png', N'shirt6_2.png', 285.000, 2)
Insert into Products values(N'Double Pocket - Xám', N'shirt7_1.png', N'shirt7_2.png', 305.000, 2)
Insert into Products values(N'Double Pocket - Trắng', N'shirt8_1.png', N'shirt8_2.png', 305.000, 2)

Insert into Products values(N'Mende Hoodie - Hate - Xanh', N'jacket1_1.png', N'jacket1_2.png', 306.600, 3)
Insert into Products values(N'Mende Hoodie - Hate - Đen', N'jacket2_1.png', N'jacket2_2.png', 306.600, 3)
Insert into Products values(N'Puzzle Varsity', N'jacket3_1.png', N'jacket3_2.png', 378.000, 3)
Insert into Products values(N'Silver Chain Varsity', N'jacket4_1.png', N'jacket4_2.png', 378.000, 3)
Insert into Products values(N'Poker Varsity 2022', N'jacket5_1.png', N'jacket5_2.png', 378.000, 3)
Insert into Products values(N'Thread Hoodie - đen', N'jacket6_1.png', N'jacket6_2.png', 420.000, 3)
Insert into Products values(N'Janky Hoodie - Nâu', N'jacket7_1.png', N'jacket7_2.png', 190.000, 3)
Insert into Products values(N'Janky Hoodie - Xanh', N'jacket8_1.png', N'jacket8_2.png', 190.000, 3)

Insert into Products values(N'Polo Empty - Đen', N'tee1_1.png', N'tee1_2.png', 320.000, 4)
Insert into Products values(N'Polo Empty - Trắng', N'tee2_1.png', N'tee2_2.png', 320.000, 4)
Insert into Products values(N'Fallen Angel Tee - Nâu', N'tee3_1.png', N'tee3_2.png', 320.000, 4)
Insert into Products values(N'Back To School Tee', N'tee4_1.png', N'tee4_2.png', 320.000, 4)
Insert into Products values(N'Titan Polo', N'tee5_1.png', N'tee5_2.png', 285.000, 4)
Insert into Products values(N'Emm Tee', N'tee6_1.png', N'tee6_2.png', 255.000, 4)
Insert into Products values(N'Mende x Degrey Tee', N'tee7_1.png', N'tee7_2.png', 245.000, 4)
Insert into Products values(N'Menbot Tee', N'tee8_1.png', N'tee8_2.png', 256.000, 4)

Insert into Products values(N'Swap Hat', N'bag1_1.png', N'bag1_2.png', 220.000, 5)
Insert into Products values(N'Vớ Mende', N'bag2_1.png', N'bag2_2.png', 30.000, 5)
Insert into Products values(N'Pastel MND Backpack', N'bag3_1.png', N'bag3_2.png', 450.000, 5)
Insert into Products values(N'Mende Rope Color Bag - Hồng', N'bag4_1.png', N'bag4_2.png', 190.000, 5)

Insert into Products values(N'Quần Nhung Tăm', N'pant1_1.png', N'pant1_2.png', 336.000, 6)
Insert into Products values(N'Brownie Cargo Pant', N'pant2_1.png', N'pant2_2.png', 289.000, 6)
Insert into Products values(N'Summer Short', N'pant3_1.png', N'pant3_2.png', 160.000, 6)
Insert into Products values(N'Mende Rock N Roll Pant', N'pant4_1.png', N'pant4_2.png', 190.000, 6)
GO

-- Create Order Table
Create table [Order]
(
  OrderId int primary key identity,
  OrderName nvarchar(50),
  OrderDate date,
  PaymentType nvarchar(50),
  Status nvarchar(50),
  CustomerName nvarchar(100),
  CustomerPhone nvarchar(15),
  CustomerEmail nvarchar(100),
  CustomerAddress nvarchar(250)
)
GO

-- Create OrderDetail Table
Create table OrderDetail
(
  OrderId int,
  ProductId int,
  Price float,
  Quantity int
  Primary key(OrderId, ProductId),
  Foreign key(OrderId) references [Order](OrderId),
  Foreign key(ProductId) references Products(ProId)
)
GO

-- Create User Table
Create table [User]
(
 UserId int primary key identity(1,1),
 UserName varchar(50),
 UserPassword varchar(255)
)
GO

CREATE TABLE Employee
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 Name VARCHAR(50),
 Designation VARCHAR(50),
 Salary INT
)
GO
-- Creating Users table
CREATE TABLE Users
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 UserName VARCHAR(50),
 UserPassword VARCHAR(50)
)
GO
-- Creating RoleMaster Table
CREATE TABLE RoleMaster
(
 ID INT PRIMARY KEY IDENTITY(1,1),
 RollName VARCHAR(50)
)
GO
-- Creating User Roles Mapping table
CREATE TABLE UserRolesMapping
(
 ID INT PRIMARY KEY,
 UserID INT NOT NULL,
 RoleID INT NOT NULL,
)
GO
-- Adding Foreign KeyS 
ALTER TABLE UserRolesMapping
ADD FOREIGN KEY (UserID) REFERENCES Users(ID);
ALTER TABLE UserRolesMapping
ADD FOREIGN KEY (RoleID) REFERENCES RoleMaster(ID);