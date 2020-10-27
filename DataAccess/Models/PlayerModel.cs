using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PlayerModel
    {
        public bool isAlive { get; set; }
        public bool isImposter { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public int TaskCount { get; set; }

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
