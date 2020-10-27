using ImposterServer.Data;
using ImposterServer.PlayerTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImposterServer.GameModels
{
    public class PlayerModel
    {
        public bool isAlive { get; set; }
        public bool isImposter { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; internal set; }
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public List<IPlayerTask> PlayerTasks { get; set; }
    }

    public enum PlayerColor
    {
        red = 0,
        blue,
        green,
        yellow,
        purple,
        black,
        white 
    }


}
