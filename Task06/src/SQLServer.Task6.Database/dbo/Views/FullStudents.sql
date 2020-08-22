CREATE VIEW [dbo].[FullStudents]
	AS 
	SELECT [p].[Id], [p].[FirstName], [p].[LastName], [p].[MiddleName], [p].[Gender], [p].[DateOfBirthday], 
		[g].[Name] AS GroupName
	FROM dbo.Students p
	left join dbo.Groups g ON p.GroupsId = g.Id
