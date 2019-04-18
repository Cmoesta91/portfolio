USE master

IF EXISTS(select * from sys.databases where name='GuildCars')
DROP DATABASE GuildCars

CREATE DATABASE GuildCars

use GuildCars
go

IF EXISTS(select * from sys.tables where name='Make')
DROP table Make
go

create table Make (
MakeID int IDENTITY(0,1) PRIMARY KEY,
MakeName varchar(50),
DateAdded date default(getdate()),
);


IF EXISTS(select * from sys.tables where name='Model')
DROP table Model
go

create table Model (
ModelID int IDENTITY(0,1) PRIMARY KEY,
ModelName varchar(50),
DateAdded date default(getdate()),
MakeID int FOREIGN KEY REFERENCES Make(MakeID), 
);




IF EXISTS(select * from sys.tables where name='Car')
DROP table Car
go

create table Car (
 CarID int IDENTITY(0,1) PRIMARY KEY,
 Vin varchar(50),
 ModelID int FOREIGN KEY REFERENCES Model(ModelID),
 MakeID int FOREIGN KEY REFERENCES Make(MakeID),
 CarYear varchar(50),
 BodyStyle varchar(50),
 Trans varchar(50),
 Color varchar(50),
 Interior varchar(50),
 Mileage varchar (50),
 SalePrice money,
 MSRP money, 
 CarDescription varchar(max),
 CarType varchar(50),
 IsFeatured bit default 'false' not null,
 IsPurchased bit default 'false' not null,
 PicturePath varchar(50) null
);



IF EXISTS(select * from sys.tables where name='Customer')
DROP table Customer
go

create table Customer(
CustomerID int IDENTITY(0,1) PRIMARY KEY,
CustomerName varchar(50),
Email varchar(50),
Phone varchar(20),
Message varchar(MAX)
);




IF EXISTS(select * from sys.tables where name='Special')
DROP table Special
go

create table Special (
SpecialID int IDENTITY(0,1) PRIMARY KEY,
SpecialName varchar (50),
SpecialDescription varchar(MAX)
);

IF EXISTS(select * from sys.tables where name='Sale')
DROP table Sale
go

create table Sale (
SaleID int IDENTITY(0,1) PRIMARY KEY,
UserId nvarchar (128) not null,
CustomerID int FOREIGN KEY REFERENCES Customer(CustomerID),
CarID int FOREIGN KEY REFERENCES Car(CarID),
DateOfSale date default(getdate()),
PurchasePrice money,
PurchaseType varchar(50),
StreetOne varchar(100) not null,
StreetTwo varchar(100) null,
City varchar(50),
SaleState varchar(50),
Zip varchar(15),
);

alter table Make
add UserId nvarchar (128) not null

alter table Model
add UserId nvarchar (128) not null

select * from Car