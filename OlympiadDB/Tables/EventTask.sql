CREATE TABLE [dbo].[EventTask]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	EventId INT NOT NULL,
	Task VARBINARY(MAX) NOT NULL
    CONSTRAINT [FK_OlympiadTask_ToOlympiad] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id]),
)
