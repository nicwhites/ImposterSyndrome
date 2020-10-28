using ImposterServer.Data;
using ImposterServer.GameModels;
using ImposterServer.PlayerTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ImposterServer.Controllers
{
   public class HostController : IDisposable
    {
        private bool disposedValue;
        public HostModel HostData { get; internal set; }
        public List<PlayerController> Players { get; internal set;}
        public HostController(int GameId)
        {
            HostData = new HostModel
            {
                GameId = GameId,
                PlayerTasks = new List<IPlayerTask>(),    
                HostId = ServersManager.ServersManager.GenerateGameId().Result
            };
            Players = new List<PlayerController>();
        }

        public async Task<int> CreatePlayer()
        {
            var player = new PlayerController();
            player.PlayerData.GameId = this.HostData.GameId;
            player.PlayerData.Color = (PlayerColor)Players.Count;
            player.EmergencyEvent += Emergency;
            // Pick a unique name
            if (Players.Count == 0)
            {
                player.PlayerData.Name = Names.List[new Random().Next(Names.List.Length)];
                Players.Add(player);
                return player.PlayerData.PlayerId;
            }
            else
            {
                player.PlayerData.Name = Names.List[new Random().Next(Names.List.Length)];
                var hsName = new HashSet<string>();
                hsName.Add(player.PlayerData.Name);
                bool uniqueName = Players.All(x => hsName.Add(x.PlayerData.Name));
                await Task.Run(() =>
                {
                    while (!uniqueName)
                    {
                        hsName.Clear(); // Clear Hashset
                    player.PlayerData.Name = Names.List[new Random().Next(Names.List.Length)]; // Generate new name
                    hsName.Add(player.PlayerData.Name);
                        uniqueName = Players.All(x => hsName.Add(x.PlayerData.Name));
                    }
                });
                Players.Add(player);
                return player.PlayerData.PlayerId;
            }
        }
        protected void Emergency(object sender, string e)
        {
            foreach(var player in Players)
            {                
                player.PlayerData.isEmergency = !player.PlayerData.isEmergency;                
            }
        }

        public void AddPlayer(PlayerController player)
        {
            Players.Add(player);
        }
        public void DeletePlayer(PlayerController player)
        {
            Players.Remove(player);
        }
        public void ReviveAllPlayer()
        {
            Players.ForEach(x => x.PlayerData.isAlive = true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                HostData = null; // Clearout host
                Players.ForEach(x => x = null); // Delete each player
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HostController()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

}
