CREATE PROCEDURE DeleteStudentsById
	@Id int
AS
	DELETE FROM Students WHERE Id = @Id
GO
