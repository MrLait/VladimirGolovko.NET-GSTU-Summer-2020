CREATE PROCEDURE GetSessionsById
	@Id int
AS
	SELECT * FROM Sessions WHERE Id = @Id
GO