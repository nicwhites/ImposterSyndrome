using ImposterSyndrome.PlayerTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImposterSyndrome.Models
{
    public class HostModel
    {
        public List<PlayerModel> players { get; set; }
        public int GameId { get; set; }
        public List<IPlayerTask> PlayerTasks { get; set; }
    }
}
