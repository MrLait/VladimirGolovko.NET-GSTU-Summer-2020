CREATE PROCEDURE [dbo].[AddSubjects]
    @Name          varchar(50),
    @IsAssessment  varchar(50)
AS
	INSERT INTO Subjects(Name, IsAssessment)
    VALUES(@Name, @IsAssessment)

    SELECT SCOPE_IDENTITY()
GO
