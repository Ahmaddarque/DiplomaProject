CREATE TABLE [dbo].[ParticipantVisit]
(
	[Id] INT NOT NULL PRIMARY KEY,
	ParticipantId INT REFERENCES Participant(Id) NOT NULL,
	[Time] DATETIME NOT NULL
)
