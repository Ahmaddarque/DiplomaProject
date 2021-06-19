CREATE TABLE [dbo].[ParticipantVerification]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ParticipantId] INT NOT NULL, 
    [CategoryType] NCHAR(10) NOT NULL, 
    [Date] DATE NOT NULL
)
