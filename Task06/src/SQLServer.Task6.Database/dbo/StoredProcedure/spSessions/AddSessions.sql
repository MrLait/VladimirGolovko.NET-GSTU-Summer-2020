CREATE PROCEDURE [dbo].[AddSessions]
    @Name   varchar(50)
AS
	INSERT INTO Sessions(Name)
    VALUES (@Name)

    SELECT SCOPE_IDENTITY()
GO