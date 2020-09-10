CREATE PROCEDURE UpdateStudents
	@Id			INT = 0,
	@FirstName  varchar(max),
	@LastName   varchar(max),
	@MiddleName varchar(max),
	@Gender     varchar(max),
	@DateOfBirthday DATETIME,
	@GroupsId   int
AS
	UPDATE Students
	SET FirstName = @FirstName, LastName = @LastName, MiddleName = @MiddleName, Gender = @Gender, DateOfBirthday = @DateOfBirthday, GroupsId = @GroupsId
	WHERE Id = @Id
	SELECT * FROM Students WHERE Id = @Id
GO
