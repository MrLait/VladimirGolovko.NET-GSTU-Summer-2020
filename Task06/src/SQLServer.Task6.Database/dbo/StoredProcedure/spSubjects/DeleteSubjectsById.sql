CREATE PROCEDURE DeleteSubjectsById
	@Id int
AS
	DELETE FROM Subjects WHERE Id = @Id
GO
