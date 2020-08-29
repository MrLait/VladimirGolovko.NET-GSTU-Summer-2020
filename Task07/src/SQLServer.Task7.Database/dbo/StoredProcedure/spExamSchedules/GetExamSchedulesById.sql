CREATE PROCEDURE GetExamSchedulesById
	@Id int
AS
	SELECT * FROM ExamSchedules WHERE Id = @Id
GO