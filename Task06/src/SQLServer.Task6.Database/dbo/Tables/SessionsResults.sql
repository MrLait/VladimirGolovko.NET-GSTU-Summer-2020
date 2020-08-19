CREATE TABLE [dbo].[SessionsResults]
(
    [Id]                INT     IDENTITY(1,1) PRIMARY KEY,
    [StudentsId]        INT                     NOT NULL,
    [ExamSchedulesId]   INT                     NOT NULL,
    [Value]             NVARCHAR (50)           NOT NULL,
    CONSTRAINT [FK_SessionsResults_Students_Id] FOREIGN KEY ([StudentsId]) REFERENCES [Students]([Id]), 
    CONSTRAINT [FK_SessionsResults_ExamSchedules_Id] FOREIGN KEY ([ExamSchedulesId]) REFERENCES [ExamSchedules]([Id]),
)
