﻿CREATE PROCEDURE ExamSchedulesPostDep
AS
DECLARE @QuantitySessions INT, @QuantityGroups INT, @QuantitySubjects INT;
DECLARE @SessionsNum INT, @GroupsNum INT, @SubjectsNum INT;
DECLARE @number INT;
DECLARE @Random INT;
SET @QuantitySessions = (SELECT COUNT(*) FROM [Sessions]);
SET @QuantityGroups = (SELECT COUNT(*) FROM Groups);
SET @QuantitySubjects = (SELECT COUNT(*) FROM Subjects);
SET @number = 1; SET @SessionsNum = 1; SET @GroupsNum = 1; SET @SubjectsNum = 1;

IF NOT EXISTS ( SELECT * FROM ExamSchedules WHERE Id = @QuantitySessions)
BEGIN
	WHILE @SessionsNum <= @QuantitySessions
		BEGIN
			WHILE @GroupsNum <= @QuantityGroups
				BEGIN
					WHILE @SubjectsNum <= @QuantitySubjects
						BEGIN
	
							SET @Random = (FLOOR(RAND()*(100-1)+1));
	
							INSERT INTO ExamSchedules (SessionsId, GroupsId, SubjectsId, ExamDate)
							VALUES (@SessionsNum,
							@GroupsNum,
							@SubjectsNum,
							DATEADD(DAY, -@Random, GETDATE())
							);
	
						SET @SubjectsNum = @SubjectsNum + 1;
	
						END;
				SET @GroupsNum = @GroupsNum + 1;
				SET @SubjectsNum = 1;
	
				END;
		
			SET @SessionsNum = @SessionsNum + 1;
			SET @GroupsNum = 1;
		END;
END;	
GO

