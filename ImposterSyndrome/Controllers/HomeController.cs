using ImposterServer.ServersManager;
using ImposterSyndrome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace ImposterSyndrome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static object _lock = new object();
        private static ServersManager server = null;

        public static ServersManager masterManager
        {
            get
            {
                lock (_lock)
                {
                    if (server is null)
                        return (server = new ServersManager());
                    else

                        return server;
                }
            }
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Host()
        {
            return RedirectToAction("Index", "Host", masterManager);
        }

        public IActionResult Player(string gameId)
        {
            int tmp = Int32.Parse(gameId);
            if (masterManager.GamesInProgress.Exists(x => x.GameId == tmp))
                return RedirectToAction("Index", "Player", masterManager.GamesInProgress.Find(x => x.GameId == tmp));
            else
                return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}