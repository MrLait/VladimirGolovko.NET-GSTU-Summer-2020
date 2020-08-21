CREATE PROCEDURE UpdateGroups
	@Id		INT = 0,
    @Name   varchar(50)
AS
	UPDATE Groups
	SET Name = @Name
	WHERE Id = @Id
	SELECT * FROM Groups WHERE Id = @Id
GO
