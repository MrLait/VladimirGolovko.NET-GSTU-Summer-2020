CREATE PROCEDURE UpdateSessionsResults
	@Id					INT = 0,
    @StudentsId         INT,
    @ExamSchedulesId    INT,
    @Value              varchar(50)
AS
	UPDATE SessionsResults
	SET StudentsId = @StudentsId, ExamSchedulesId = @ExamSchedulesId, Value = @Value
	WHERE Id = @Id
	SELECT * FROM SessionsResults WHERE Id = @Id
GO
