CREATE PROCEDURE UpdateSubjects
	@Id			INT = 0,
    @Name          varchar(50),
    @IsAssessment  varchar(50)
AS
	UPDATE Subjects
	SET Name = @Name, IsAssessment = @IsAssessment
	WHERE Id = @Id
	SELECT * FROM Subjects WHERE Id = @Id
GO