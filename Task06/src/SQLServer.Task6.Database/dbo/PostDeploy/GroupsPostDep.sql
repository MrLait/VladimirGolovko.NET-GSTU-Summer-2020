CREATE PROCEDURE GroupsPostDep
AS
DECLARE @number INT;
DECLARE @GroupPrefix NVARCHAR(40);
DECLARE @Random INT;
DECLARE @GroupNum INT;
SET @number = 1;
SET @GroupPrefix = 'PM-';
SET @GroupNum = 4

IF NOT EXISTS(SELECT * FROM Groups WHERE Id = @GroupNum)
BEGIN
	WHILE @number < @GroupNum + 1
		BEGIN
			INSERT INTO Groups ([Name])
			VALUES (@GroupPrefix + CONVERT(NVARCHAR, @number));
			SET @number = @number + 1;
	
		END;
END;
GO