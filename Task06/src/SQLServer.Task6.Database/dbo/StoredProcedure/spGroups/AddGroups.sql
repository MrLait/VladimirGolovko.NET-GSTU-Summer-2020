CREATE PROCEDURE [dbo].[AddGroups]
    @Name   varchar(50)
AS
	INSERT INTO Sessions(Name)
    VALUES (@Name)

    SELECT SCOPE_IDENTITY()
GO
