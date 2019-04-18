use DVDLibrary
go

IF EXISTS(
   SELECT *
   FROM sys.server_principals
   WHERE [Name] = 'DvdLibrary')
BEGIN
   DROP LOGIN DvdLibrary
END
GO

 IF EXISTS(
   SELECT *
   FROM sys.database_principals
   WHERE [Name] = 'DvdLibrary')
BEGIN
   DROP User DvdLibrary
END

create login DVDLibrary with password='Testing123'
go

create user DVDLibrary for login DVDLibrary
go

grant execute on CreateDVD to DVDLibrary
grant execute on DeleteDVD to DVDLibrary
grant execute on GetAll to DVDLibrary
grant execute on GetById to DVDLibrary
grant execute on GetDirector to DVDLibrary
grant execute on GetRating to DVDLibrary
grant execute on GetTitle to DVDLibrary
grant execute on GetYear to DVDLibrary
grant execute on UpdateDVD to DVDLibrary
go

GRANT SELECT ON DVDs TO DVDLibrary
GRANT INSERT ON DVDs TO DVDLibrary
GRANT UPDATE ON DVDs TO DVDLibrary
GRANT DELETE ON DVDs TO DVDLibrary
GO
