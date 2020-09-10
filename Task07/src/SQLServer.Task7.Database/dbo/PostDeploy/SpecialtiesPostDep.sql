CREATE PROCEDURE SpecialtiesPostDep
AS
DECLARE @number INT;
DECLARE @SpecialtyPrefix NVARCHAR(40);
DECLARE @InfoPrefix NVARCHAR(40);
DECLARE @Random INT;
DECLARE @SpecialtyNum INT;
SET @number = 1;
SET @SpecialtyNum = 2;
SET @SpecialtyPrefix = 'Specialty-';
SET @InfoPrefix = 'Info-';

IF NOT EXISTS(SELECT * FROM Groups WHERE Id = @SpecialtyNum)
BEGIN
	WHILE @number <= @SpecialtyNum
		BEGIN
			INSERT INTO Specialties([Name], [Info])
			VALUES (@SpecialtyPrefix + CONVERT(NVARCHAR, @number), @InfoPrefix + CONVERT(NVARCHAR, @number));
			SET @number = @number + 1;
		END;
END;
GO