CREATE TABLE [dbo].[Testing]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EventId] INT NOT NULL, 
    [Name] VARCHAR(150) NULL, 
    CONSTRAINT [FK_Testing_ToEvent] FOREIGN KEY ([EventId]) REFERENCES [Event]([Id]), 
    CONSTRAINT [AK_EventId] UNIQUE ([EventId])
)
