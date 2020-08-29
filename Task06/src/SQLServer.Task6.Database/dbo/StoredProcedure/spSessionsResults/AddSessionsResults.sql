CREATE PROCEDURE AddSessionsResults
    @StudentsId         INT,
    @ExamSchedulesId    INT,
    @Value              varchar(50)
AS
    INSERT INTO SessionsResults (StudentsId, ExamSchedulesId, Value)
    VALUES (@StudentsId, @ExamSchedulesId, @Value)

     SELECT SCOPE_IDENTITY()
GO
