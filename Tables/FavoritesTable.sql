CREATE TABLE [dbo].[Table]
(
	[Id] INT NULL PRIMARY KEY, 
    [FavFood] NVARCHAR(50) NOT NULL, 
    [FavFruit] NVARCHAR(50) NOT NULL, 
    [FavColor] NVARCHAR(50) NOT NULL, 
    [FavIceCream] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Id])
)
