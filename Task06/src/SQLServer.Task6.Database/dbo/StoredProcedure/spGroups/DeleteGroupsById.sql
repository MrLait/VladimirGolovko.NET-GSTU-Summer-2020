CREATE PROCEDURE DeleteGroupsById
	@Id int
AS
	DELETE FROM Groups WHERE Id = @Id
Go
