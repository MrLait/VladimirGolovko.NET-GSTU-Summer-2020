CREATE PROCEDURE GetSubjectsById
	@Id int
AS
	SELECT * FROM Subjects WHERE Id = @Id
GO
