CREATE TABLE [dbo].[Players]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [GameId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [isAlive] BIT NOT NULL, 
    [isImposter] BIT NOT NULL, 
    [Color] NCHAR(10) NOT NULL, 
    [RemainingTasks] INT NOT NULL
)
