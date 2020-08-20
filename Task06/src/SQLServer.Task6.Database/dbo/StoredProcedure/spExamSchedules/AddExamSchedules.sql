CREATE PROCEDURE [dbo].[AddExamSchedules]
	@SessionsId    INT,
    @GroupsId      INT,
    @SubjectsId    INT,
    @ExamDate      DATETIME
AS
	INSERT INTO ExamSchedules(SessionsId, GroupsId, SubjectsId, ExamDate)
    VALUES(@SessionsId, @GroupsId, @SubjectsId, @ExamDate)

    SELECT SCOPE_IDENTITY()
GO

  