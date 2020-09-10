CREATE PROCEDURE DeleteExamSchedulesById
	@Id int
AS
	DELETE FROM ExamSchedules WHERE Id = @Id
Go
