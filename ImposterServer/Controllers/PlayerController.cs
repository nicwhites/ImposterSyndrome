using ImposterServer.Data;
using ImposterServer.GameModels;
using System;

namespace ImposterServer.Controllers
{
    public class PlayerController
    {
        public PlayerModel PlayerData { get; internal set; }

        public event EventHandler<string> EmergencyEvent;

        public PlayerController()
        {
            PlayerData = new PlayerModel
            {
                PlayerId = ServersManager.ServersManager.GenerateGameId().Result,
                isAlive = true,
                isImposter = false,
            };
        }
        public void RaiseEmergency()
        {
            EmergencyEvent?.Invoke(this, $"{PlayerData.Name} Sounded the Alarm!"); // Trigger the Event
        }

        public void ReceivedEmergency()
        {
            this.PlayerData.isEmergency = false;
        }
    }
}