﻿CREATE TABLE [dbo].[Specialties]
(
    [Id]        INT IDENTITY(1,1)   PRIMARY KEY,
    [Name]      NVARCHAR(50)         NOT NULL,
    Info        NVARCHAR(MAX)
)
