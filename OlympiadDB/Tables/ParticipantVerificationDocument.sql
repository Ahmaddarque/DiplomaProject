CREATE TABLE [dbo].[ParticipantVerificationDocument]
(
	[Id] INT NOT NULL PRIMARY KEY,
	ParticipantVerificationId INT REFERENCES ParticipantVerification(Id) NOT NULL, 
    [File] VARBINARY(50) NOT NULL
)
