CREATE PROCEDURE GetStudentsById
	@Id int
AS
	SELECT * FROM Students WHERE Id = @Id
GO