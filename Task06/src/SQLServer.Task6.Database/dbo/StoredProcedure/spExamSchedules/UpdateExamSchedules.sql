CREATE PROCEDURE UpdateExamSchedules
	@Id            INT = 0,
    @SessionsId    INT,
    @GroupsId      INT,
    @SubjectsId    INT,
    @ExamDate      DATETIME
AS
	UPDATE ExamSchedules
    SET SessionsId = @SessionsId, GroupsId = @GroupsId, SubjectsId = @SubjectsId, ExamDate = @ExamDate
    WHERE Id = @Id
    SELECT * FROM ExamSchedules WHERE Id = @Id
GO
