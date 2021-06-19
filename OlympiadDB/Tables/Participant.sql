CREATE TABLE [dbo].[Participant]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Surname] NVARCHAR(50) NOT NULL, 
    [Lastname] NVARCHAR(50) NULL, 
    [Phone] VARCHAR(25) NOT NULL, 
    [Email] VARCHAR(100) unique NOT NULL, 
    EducationInstitution varchar(max) not null,
    [Sex] INT NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Login] VARCHAR(20) unique NOT NULL, 
    [Password] VARCHAR(20) NOT NULL, 
    [RegistrationTime] DATETIME NOT NULL,
    RegistrationIP VARCHAR(45) NULL, 

    CONSTRAINT [AK_Participant_Email] UNIQUE ([Email]), 
    CONSTRAINT [AK_Participant_Phone] UNIQUE ([Phone]) 
)
