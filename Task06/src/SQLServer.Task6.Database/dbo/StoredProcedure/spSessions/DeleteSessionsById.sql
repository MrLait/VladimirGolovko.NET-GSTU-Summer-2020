CREATE PROCEDURE DeleteSessionsById
	@Id int
AS
	DELETE FROM Sessions WHERE Id = @Id
GO
