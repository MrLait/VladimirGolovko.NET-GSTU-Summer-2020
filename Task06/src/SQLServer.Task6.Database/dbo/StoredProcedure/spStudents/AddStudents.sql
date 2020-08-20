CREATE PROCEDURE AddStudents
@FirstName  varchar(max),
@LastName   varchar(max),
@MiddleName varchar(max),
@Gender     varchar(max),
@DateOfBirthday DATETIME,
@GroupsID   int
AS 
    INSERT INTO Students( FirstName, LastName, MiddleName, Gender, DateOfBirthday, GroupsID)
    VALUES (@FirstName, @LastName, @MiddleName, @Gender, @DateOfBirthday, @GroupsID)
    
    SELECT SCOPE_IDENTITY()
Go
