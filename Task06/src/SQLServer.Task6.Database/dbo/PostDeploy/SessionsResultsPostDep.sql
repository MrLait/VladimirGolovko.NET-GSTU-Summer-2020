CREATE PROCEDURE SessionsResultsPostDep
AS
DECLARE @QuantityStudents INT, @QuantitySubjects INT, @QuantitySessions INT;
DECLARE @StudentsNum INT, @ExamSchedulesNum INT, @SubjectsNum INT, @SessionsNum INT;--, @SubjectsNum INT;
DECLARE @ExamSchedulesId INT;
DECLARE @ExamValueINT INT, @ExamValueVarChar VARCHAR(max);
DECLARE @IsAssessment VARCHAR(max);
DECLARE @Boolean BIT;

SET @Boolean = 1;
SET @QuantityStudents = (SELECT COUNT(*) FROM Students);
SET @QuantitySessions =(SELECT COUNT(*) FROM [Sessions]);
SET @StudentsNum = 0; SET @ExamSchedulesNum = 1; SET @SubjectsNum = 1; SET @SessionsNum = 1;

IF NOT EXISTS(SELECT * FROM SessionsResults WHERE Id = @QuantitySessions)
BEGIN
	WHILE @SessionsNum <= @QuantitySessions
	BEGIN
		WHILE @StudentsNum <= @QuantityStudents
		BEGIN
					
			WHILE @QuantitySubjects <=
			(SELECT COUNT(*) FROM ExamSchedules Where ExamSchedules.GroupsId = 
			(SELECT Students.GroupsId FROM Students Where Students.Id = @StudentsNum) AND ExamSchedules.SessionsId = @SessionsNum)
			
			BEGIN
		
				SET @ExamSchedulesId = (SELECT ExamSchedules.Id FROM ExamSchedules Where ExamSchedules.GroupsId = 
				(SELECT Students.GroupsId FROM Students Where Students.Id = @StudentsNum)
				AND ExamSchedules.SubjectsId = @QuantitySubjects AND ExamSchedules.SessionsId = @SessionsNum);
		
				SET @IsAssessment = 
				(SELECT Subjects.IsAssessment FROM Subjects WHERE Subjects.Id = 
				(SELECT ExamSchedules.SubjectsId FROM ExamSchedules WHERE ExamSchedules.Id = @ExamSchedulesId));
		
				IF (@IsAssessment = 'True')
					begin
						IF (@ExamValueVarChar = 'False')
							begin
								SET @ExamValueVarChar = 0;
							end;
						else
							begin
								SET @ExamValueVarChar = (FLOOR(RAND()*(100-1)+1))
							end;
					end;
				else
					begin
						SET	@Boolean = CAST(ROUND(RAND(), 0) AS BIT);
						SET @ExamValueVarChar =  Cast(Case When @Boolean=1 Then 'True' ELSE 'False' END AS VARCHAR(max));
					end;

				INSERT INTO SessionsResults(StudentsId, ExamSchedulesId, Value)
				VALUES (@StudentsNum,
						@ExamSchedulesId,
						@ExamValueVarChar);
		
				SET @QuantitySubjects = @QuantitySubjects + 1;
		
			END;
			SET @QuantitySubjects = 1;
		
			SET @StudentsNum = @StudentsNum + 1;
		END;

		SET @StudentsNum = 1;
		SET @SessionsNum = @SessionsNum + 1;
	END;
END;
GO