using DataAccess.DataAccess;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.BusinessLogic
{
    public class HostProcessor
    {
        public static int CreateGame(HostModel Host)
        {
            var data = new HostModel
            {
                GameId = Host.GameId,
                isRunning = true,
                isStarted = false,
                TotalPlayers = 0,
                PlayerTaskCount = 0
            };
            string sql = @"insert into dbo.Players (GameId, isRunning, isStarted, TotalPlayers, PlayerTaskCount)
                            values (@GameId, @isRunning, @isStarted, @TotalPlayers, @PlayerTaskCount)";
            return SQLDataAccess.SaveData(sql, data);
        }

        public static void StartGame(HostModel host)
        {
        }

        public static void StopGame(HostModel host)
        {
        }

        public static void DeleteGame(HostModel host)
        {
        }

        public static List<PlayerModel> GetPlayers(HostModel host)
        {
            string sql = $@"select *
                           from Players
                           Where GameId = {host.GameId}";
            return SQLDataAccess.LoadData<PlayerModel>(sql);
        }
    }
}