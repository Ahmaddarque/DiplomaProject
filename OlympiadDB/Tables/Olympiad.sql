﻿CREATE TABLE [dbo].[Olympiad]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    EventId INT UNIQUE NOT NULL,
    [StartTime] DATETIME NOT NULL, 
    [EndTime] DATETIME NOT NULL 
)
