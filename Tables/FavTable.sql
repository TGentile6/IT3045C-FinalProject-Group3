CREATE TABLE [dbo].[Table]
(
	[Id] INT NULL PRIMARY KEY, 
    [Hometown] NVARCHAR(50) NOT NULL, 
    [State] NVARCHAR(2) NOT NULL, 
    [HS] NVARCHAR(50) NOT NULL, 
    [HSGradYear] INT NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
