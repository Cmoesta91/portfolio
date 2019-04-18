create database DVDLibrary
go

use DVDLibrary
go

create table DVDs (
	DvdId int Primary Key Identity(0,1), 
	Title varchar(255),
	RealeaseYear varchar(255),
	Director varchar(255),
	Rating varchar(255),
	Notes varchar(255)
);





