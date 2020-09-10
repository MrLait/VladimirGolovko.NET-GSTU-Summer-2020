CREATE PROCEDURE SessionsPostDep
AS
DECLARE @number INT, @SessionsNum INT;
DECLARE @GroupNum INT;
SET @number = 1;
SET @SessionsNum = 2

IF NOT EXISTS(SELECT * FROM Sessions WHERE Id = @SessionsNum)
BEGIN
	WHILE @number <= @SessionsNum
		BEGIN
			INSERT INTO Sessions(Name)
			VALUES (@number);
			SET @number = @number + 1;
		END;
END;
GO