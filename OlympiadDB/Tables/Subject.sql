CREATE TABLE [dbo].[Subject]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) unique NOT NULL, 
    CONSTRAINT [AK_Subject_Name] UNIQUE ([Name])
)
