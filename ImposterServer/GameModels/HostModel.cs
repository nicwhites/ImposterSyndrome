using ImposterServer.PlayerTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImposterServer.GameModels
{
    public class HostModel
    {
        public int GameId { get; set; }
        public int HostId { get; set; }
        public List<IPlayerTask> PlayerTasks { get; set; }
        public GameSettingsModel gameSettings { get; set; }
    }
}
