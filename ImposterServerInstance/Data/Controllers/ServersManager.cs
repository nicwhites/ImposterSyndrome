using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ImposterServerInstance.GameModels;
using ImposterServerInstance.Controllers;

namespace ImposterServerInstance.ServersManager
{
    public class ServersManager
    {
        public List<GameController> GamesInProgress { get; set; }

        public int AmountOfGames { get; internal set; }

        public ServersManager()
        {
            AmountOfGames = 0;
            GamesInProgress = new List<GameController>();
        }

        public GameController HostNewGame()
        {
            var newGame = new GameController(GenerateGameId().Result);
            this.GamesInProgress.Add(newGame);
            AmountOfGames++;
            return newGame;
        }
        public PlayerController FindPlayer(int gameId, int playerId)
        {
            return GamesInProgress.Find(x => x.GameId == gameId).Host.Players.Find(x => x.PlayerData.PlayerId == playerId);
        }
        public HostController FindHost(int gameId, int hostId)
        {
            return GamesInProgress.Find(x => x.GameId == gameId).Host;
        }

        public void RemoveGame(GameController game)
        {
            GamesInProgress.Remove(game);
        }

        public static Task<int> GenerateGameId()
        {
            return Task.Run(() => new Random().Next(100000, 999999));
        }


    }
}
