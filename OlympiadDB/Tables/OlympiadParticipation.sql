CREATE TABLE [dbo].[OlympiadParticipation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OlympiadId] INT NOT NULL, 
    [ParticipantId] INT NOT NULL, 
    CONSTRAINT [FK_OlympiadParticipation_ToOlympiad] FOREIGN KEY ([OlympiadId]) REFERENCES [Olympiad]([Id]), 
    CONSTRAINT [FK_OlympiadParticipation_ToParticipant] FOREIGN KEY ([Id]) REFERENCES [Participant]([Id])
)
