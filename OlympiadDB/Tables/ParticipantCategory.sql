CREATE TABLE [dbo].[ParticipantCategory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [AK_ParticipantCategory_Name] UNIQUE ([Name])
)
