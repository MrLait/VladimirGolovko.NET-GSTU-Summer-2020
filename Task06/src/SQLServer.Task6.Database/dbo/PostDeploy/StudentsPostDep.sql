CREATE PROCEDURE StudentsPostDep
AS
DECLARE @QuantityGroups INT;
DECLARE @number INT;
DECLARE @Random INT;
DECLARE @StudentsNum INT;
DECLARE @FirstNamePrefix NVARCHAR(40), @LastNamePrefix NVARCHAR(40), @MiddleNamePrefix NVARCHAR(40), @Gender NVARCHAR(40);
SET @QuantityGroups = (SELECT COUNT(*) FROM Groups) + 1;
SET @number = 1;
SET @StudentsNum = 10
SET @FirstNamePrefix = 'FirstName';
SET @LastNamePrefix = 'LastName';
SET @MiddleNamePrefix = 'Middlename';

IF NOT EXISTS(SELECT * FROM Students WHERE Id = @StudentsNum)
BEGIN
	WHILE @number < @StudentsNum + 1
		BEGIN
	
			IF (FLOOR(RAND()*(10-1)+1) < 5)
				SET @Gender = 'Male';
			ELSE
				SET @Gender = 'Female';
			
			SET @Random = (FLOOR(RAND()*(@QuantityGroups-1)+1));
	
			INSERT INTO Students(FirstName, LastName, MiddleName,Gender, DateOfBirthday, GroupsId)
			VALUES (@FirstNamePrefix + CONVERT(NVARCHAR, @number),
					@LastNamePrefix + CONVERT(NVARCHAR, @number),
					@MiddleNamePrefix + CONVERT(NVARCHAR, @number),
					@Gender,
					DATEADD(DAY, -@number, GETDATE()),
					@Random);
	
			SET @number = @number + 1;
		END;
END;
GO