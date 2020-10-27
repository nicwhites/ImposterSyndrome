CREATE TABLE [dbo].[Games]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GameId] INT NOT NULL, 
    [isRunning] BIT NOT NULL, 
    [TotalPlayers] INT NOT NULL, 
    [RemainingTasks] INT NOT NULL, 
    [isStarted] BIT NOT NULL
)
