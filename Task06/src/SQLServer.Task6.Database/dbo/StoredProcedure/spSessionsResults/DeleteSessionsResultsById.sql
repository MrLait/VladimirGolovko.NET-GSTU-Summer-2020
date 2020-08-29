CREATE PROCEDURE DeleteSessionsResultsById
	@Id int
AS
	DELETE FROM SessionsResults WHERE Id = @Id
GO