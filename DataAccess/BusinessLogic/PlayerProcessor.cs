using DataAccess.DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.BusinessLogic
{
    public static class PlayerProcessor
    {
        public static int CreatePlayer(PlayerModel player, GameSettings settings)
        {
            var data = new PlayerModel
            {
                GameId = player.GameId,
                Color = player.Color,
                Name = player.Name,
                isAlive = true,
                isImposter = false,
                TaskCount = settings.AmountOfTasks
            };
            string sql = @"insert into dbo.Players (GameId, Name, isAlive, isImposter, Color, RemainingTasks)
                            values (@GameId, @Name, @isAlive, @isImposter, @Color, @TaskCount)";
            return SQLDataAccess.SaveData(sql, data);

        }
        public static void DeletePlayer(PlayerModel player)
        {

        }
        public static void KillPlayer(PlayerModel player)
        {

        }
        public static void RevivePlayer(PlayerModel player)
        {

        }
        public static void PlayerCompletedTask(PlayerModel player)
        {

        }
    }
}
