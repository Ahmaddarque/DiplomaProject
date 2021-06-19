CREATE TABLE [dbo].[Event]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(150) NOT NULL, 
    [ParticipantCategoryId] INT NOT NULL, 
    [EventType] INT NOT NULL, 
    [SubjectId] INT NOT NULL, 
    CONSTRAINT [FK_Event_ToParticipantCategory] FOREIGN KEY ([ParticipantCategoryId]) REFERENCES [ParticipantCategory]([Id]), 
    CONSTRAINT [FK_Event_ToSubject] FOREIGN KEY ([Id]) REFERENCES [Subject]([Id]) 
)
