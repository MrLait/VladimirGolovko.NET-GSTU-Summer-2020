CREATE PROCEDURE SubjectsPostDep
AS
DECLARE @QuantitySubject INT, @QuantityExaminers INT;
DECLARE @number INT;
DECLARE @SybjectsPrefix NVARCHAR(50), @IsAssessment NVARCHAR(50);
DECLARE @Random INT;
DECLARE @ExaminersId INT;
SET @number = 1;
SET @QuantitySubject = 2;
SET @SybjectsPrefix = 'Subject-';
SET @IsAssessment = 'False';
SET @QuantityExaminers = (SELECT COUNT(e.Id) FROM Examiners e);
SET @ExaminersId = 1;

IF NOT EXISTS(SELECT * FROM Subjects WHERE Id = @QuantitySubject)
BEGIN
	WHILE @number <= (@QuantitySubject)
		BEGIN
			INSERT INTO Subjects(Name, IsAssessment, [ExaminersId])
			VALUES (@SybjectsPrefix + CONVERT(NVARCHAR, ROUND((@number + 1)/2 - 0.3,0)), @IsAssessment, @ExaminersId);
	
			SET @number = @number + 1;
	
			IF (@number%2 = 0)
				SET @IsAssessment = 'True';
			ELSE
				SET @IsAssessment = 'False';

			IF (@IsAssessment = 'False')
				IF @ExaminersId = @QuantityExaminers
					SET @ExaminersId = 1;
				ELSE
					SET @ExaminersId = @ExaminersId + 1;


		END;
END;	
GO