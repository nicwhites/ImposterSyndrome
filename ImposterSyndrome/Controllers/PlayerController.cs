using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImposterServer.GameModels;
using ImposterServer.Managers;
using ImposterServer.ServersManager;
using Microsoft.AspNetCore.Mvc;

namespace ImposterSyndrome.Controllers
{
    public class PlayerController : Controller
    {
        public PlayerModel player;
        public IActionResult Index(HostController host)
        {
            var newPlayer = new PlayerModel
            {
                GameId = host.Host.GameId,
                Color = PlayerColor.red,
                isAlive = true,
                isImposter = false,
                PlayerTasks = new List<ImposterServer.PlayerTask.IPlayerTask>()           
            };

            host.AddPlayer(player);
            return View(player);
        }
    }
}
