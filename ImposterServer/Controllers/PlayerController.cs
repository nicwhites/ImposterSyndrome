using ImposterServer.Data;
using ImposterServer.GameModels;
using System;

namespace ImposterServer.Controllers
{
    public class PlayerController
    {
        public PlayerModel PlayerData { get; internal set; }

        public PlayerController()
        {
            PlayerData = new PlayerModel
            {
                PlayerId = ServersManager.ServersManager.GenerateGameId().Result,
                isAlive = true,
                isImposter = false,
            };
        }
    }
}