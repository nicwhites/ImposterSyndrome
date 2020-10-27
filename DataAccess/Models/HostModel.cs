
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class HostModel
    {
        public int GameId { get; set; }
        public int PlayerTaskCount { get; set; }
        public bool isStarted { get; set; }
        public bool isRunning { get; set; }
        public int TotalPlayers { get; set; }
    }
}
