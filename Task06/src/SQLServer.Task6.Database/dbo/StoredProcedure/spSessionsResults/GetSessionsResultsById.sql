CREATE PROCEDURE GetSessionsResultsById
	@Id int
AS
	SELECT * FROM SessionsResults WHERE Id = @Id
GO
