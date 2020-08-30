CREATE TABLE [dbo].[Groups]
(
    [Id]            INT IDENTITY(1,1)   PRIMARY KEY,
    [Name]          NVARCHAR (50)       NOT NULL,
    SpecialtiesId   INT                 NOT NULL, 
    CONSTRAINT [FK_Groups_ToSpecialties] FOREIGN KEY ([SpecialtiesId]) REFERENCES [Specialties]([Id])
)
