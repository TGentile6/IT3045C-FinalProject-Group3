CREATE TABLE [dbo].[Table]
(
	[Id] INT NULL PRIMARY KEY, 
    [FavGenre] NVARCHAR(50) NOT NULL, 
    [Num_Concerts_Attended] INT NOT NULL, 
    [Last_Concert] NVARCHAR(50) NOT NULL, 
    [Music_Platform] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
