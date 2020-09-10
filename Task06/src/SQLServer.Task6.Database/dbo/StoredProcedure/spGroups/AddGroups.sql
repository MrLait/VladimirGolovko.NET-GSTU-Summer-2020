CREATE PROCEDURE [dbo].[AddGroups]
    @Name   varchar(50)
AS
	INSERT INTO Groups(Name)
    VALUES (@Name)

    SELECT SCOPE_IDENTITY()
GO
