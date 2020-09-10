CREATE PROCEDURE ExaminersPostDep
AS
DECLARE @number INT;
DECLARE @Random INT;
DECLARE @ExaminersNum INT;
DECLARE @FirstNamePrefix NVARCHAR(50), @LastNamePrefix NVARCHAR(50), @MiddleNamePrefix NVARCHAR(50)
SET @number = 1;
SET @ExaminersNum = 2
SET @FirstNamePrefix = 'FirstName';
SET @LastNamePrefix = 'LastName';
SET @MiddleNamePrefix = 'MiddleName';

IF NOT EXISTS(SELECT * FROM Examiners WHERE Id = @ExaminersNum)
BEGIN
	WHILE @number <= @ExaminersNum
		BEGIN
			INSERT INTO Examiners(FirstName, LastName, MiddleName)
			VALUES (@FirstNamePrefix + CONVERT(NVARCHAR, @number),
					@LastNamePrefix + CONVERT(NVARCHAR, @number),
					@MiddleNamePrefix + CONVERT(NVARCHAR, @number));
			SET @number = @number + 1;
		END;
END;
GO