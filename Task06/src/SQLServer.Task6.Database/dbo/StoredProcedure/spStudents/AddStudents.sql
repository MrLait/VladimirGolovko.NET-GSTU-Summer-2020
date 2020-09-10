CREATE PROCEDURE AddStudents
@FirstName  varchar(max),
@LastName   varchar(max),
@MiddleName varchar(max),
@Gender     varchar(max),
@DateOfBirthday DATETIME,
@GroupsId   int
AS 
    INSERT INTO Students( FirstName, LastName, MiddleName, Gender, DateOfBirthday, GroupsId)
    VALUES (@FirstName, @LastName, @MiddleName, @Gender, @DateOfBirthday, @GroupsId)
    
    SELECT SCOPE_IDENTITY()
Go
