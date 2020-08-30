CREATE TABLE [dbo].[Subjects]
(
    [Id]            INT IDENTITY(1,1)   PRIMARY KEY,
    [Name]          NVARCHAR (50)       NOT NULL,
    [IsAssessment]  NVARCHAR(50)        NOT NULL,
    ExaminersId     INT                 NOT NULL, 
    CONSTRAINT [FK_Subjects_ToExaminers] FOREIGN KEY ([ExaminersId]) REFERENCES [Examiners]([Id]) 
)
