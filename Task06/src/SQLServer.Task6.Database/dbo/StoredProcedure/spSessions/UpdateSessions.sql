CREATE PROCEDURE UpdateSessions
	@Id		INT = 0,
    @Name   varchar(50)
AS
	UPDATE Sessions
	SET Name = @Name
	WHERE Id = @Id
	SELECT * FROM Sessions WHERE Id = @Id
GO