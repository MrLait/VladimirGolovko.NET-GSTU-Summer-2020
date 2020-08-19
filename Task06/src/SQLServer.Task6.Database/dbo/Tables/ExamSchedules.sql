CREATE TABLE [dbo].[ExamSchedules]
(
    [Id]            INT IDENTITY(1,1)   PRIMARY KEY,
    [SessionsId]    INT                 NOT NULL,
    [GroupsId]      INT                 NOT NULL,
    [SubjectsId]    INT                 NOT NULL,
    [ExamDate]      DATETIME            NOT NULL,
    CONSTRAINT [FK_ExamSchedules_Sessions_Id] FOREIGN KEY ([SessionsId]) REFERENCES [Sessions]([Id]), 
    CONSTRAINT [FK_ExamSchedules_Groups_Id] FOREIGN KEY ([GroupsId]) REFERENCES [Groups]([Id]), 
    CONSTRAINT [FK_ExamSchedules_Subjects_Id] FOREIGN KEY ([SubjectsId]) REFERENCES [Subjects]([Id])
)
