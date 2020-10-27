using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImposterServer.Managers;
using ImposterServer.ServersManager;
using Microsoft.AspNetCore.Mvc;

namespace ImposterSyndrome.Controllers
{
    public class HostController : Controller
    {
        public IActionResult Index(ServersManager server)
        {
            var Game = server.HostNewGame();
            return View(Game);
        }
    }
}
