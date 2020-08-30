CREATE PROCEDURE GroupsPostDep
AS
DECLARE @number INT, @SpecialtyNum INT;
DECLARE @GroupPrefix NVARCHAR(40);
DECLARE @Random INT;
DECLARE @GroupNum INT;
DECLARE @QuantitySpecialties INT;
SET @number = 1;
SET @GroupPrefix = 'PM-';
SET @GroupNum = 2
SET @QuantitySpecialties = (SELECT Count(s.Id) FROM Specialties s);
SET @SpecialtyNum = 1;

IF NOT EXISTS(SELECT * FROM Groups WHERE Id = @GroupNum)
BEGIN
	WHILE @number <= @GroupNum
		BEGIN
			INSERT INTO Groups ([Name], [SpecialtiesId])
			VALUES (@GroupPrefix + CONVERT(NVARCHAR, @number), @SpecialtyNum);
			SET @number = @number + 1;
			
			IF @SpecialtyNum = @QuantitySpecialties
				SET @SpecialtyNum = 1;
			ELSE
				SET @SpecialtyNum = @SpecialtyNum + 1;
		END;
END;
GO