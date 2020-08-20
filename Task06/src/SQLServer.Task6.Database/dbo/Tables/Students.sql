CREATE TABLE [dbo].[Students]
(
    [Id]                INT IDENTITY(1,1)   PRIMARY KEY,
    [FirstName]         NVARCHAR (50)       NOT NULL,
    [LastName]          NVARCHAR (50)       NOT NULL,
    [MiddleName]        NVARCHAR (50)       NOT NULL,
    [Gender]            NVARCHAR (50)       NOT NULL,
    [DateOfBirthday]    DATETIME            NOT NULL,
    [GroupsId]          INT                 NOT NULL, 
    CONSTRAINT [FK_Students_Groups_Id] FOREIGN KEY ([GroupsId]) REFERENCES [Groups]([Id]),
)
