﻿CREATE PROCEDURE GetGroupsById
	@Id int
AS
	SELECT * FROM Groups WHERE Id = @Id
GO