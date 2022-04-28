CREATE TABLE [dbo].[Table]
(
	[Id] INT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Birthdate] DATETIME NOT NULL, 
    [College_Program] NVARCHAR(50) NOT NULL, 
    [Program_Year] INT NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
