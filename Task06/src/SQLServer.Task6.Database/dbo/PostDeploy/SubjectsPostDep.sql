CREATE PROCEDURE SubjectsPostDep
AS
DECLARE @QuantitySubject INT;
DECLARE @number INT;
DECLARE @SybjectsPrefix NVARCHAR(40), @IsAssessment NVARCHAR(40);
DECLARE @Random INT;
SET @number = 1;
SET @QuantitySubject = 4;
SET @SybjectsPrefix = 'Subject-';
SET @IsAssessment = 'False';

IF NOT EXISTS(SELECT * FROM Subjects WHERE Id = @QuantitySubject)
BEGIN
	WHILE @number <= (@QuantitySubject)
		BEGIN
			INSERT INTO Subjects(Name, IsAssessment)
			VALUES (@SybjectsPrefix + CONVERT(NVARCHAR, ROUND((@number + 1)/2 - 0.3,0)), @IsAssessment);
	
			SET @number = @number + 1;
	
			IF (@number%2 = 0)
				SET @IsAssessment = 'True';
			ELSE
				SET @IsAssessment = 'False';
		END;
END;	
GO