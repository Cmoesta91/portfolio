use DVDLibrary
go

create procedure GetAll

as
select * 
from DVDs

go

create procedure CreateDVD
@Title varchar(50),
@RealeaseYear varchar(50),
@Director varchar(50),
@Rating varchar(50),
@Notes varchar(50) null 
as
insert into DVDs (Title, RealeaseYear, Director, Rating, Notes)
values (@Title, @RealeaseYear, @Director, @Rating, @Notes)

go

create procedure DeleteDVD
@DvdId int
as
delete from DVDs
where DvdId = @DvdId;

go

create procedure GetById
@DvdId int
as
select *
from DVDs
where DvdId = @DvdId;

go

create procedure UpdateDVD
@DvdId int,
@Title varchar(50),
@RealeaseYear varchar(50),
@Director varchar(50),
@Rating varchar(50),
@Notes varchar(50) null
as
update DVDs
set Title = @Title, RealeaseYear = @RealeaseYear,
Director = @Director, Rating = @Rating, Notes = @Notes
where DvdId = @DvdId

go

create procedure GetDirector
@Director varchar(50)
as
select *
from DVDs
where Director = @Director

go

create procedure GetRating
@Rating varchar(50)
as
select *
from DVDs
where Rating = @Rating

go

create procedure GetTitle
@Title varchar(50)
as
select *
from DVDs
where Title = @Title

go

create procedure GetYear
@Year varchar(50)
as
select *
from DVDs
where RealeaseYear = @Year

go