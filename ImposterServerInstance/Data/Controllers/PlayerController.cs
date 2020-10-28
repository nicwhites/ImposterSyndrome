using ImposterServer.Data;
using ImposterServerInstance.GameModels;

using Microsoft.AspNetCore.Components;
using System;

namespace ImposterServerInstance.Controllers
{
    public partial class PlayerController : ComponentBase
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
            this.PlayerData.isEmergency = true;
            try
            {
                InvokeAsync(() => StateHasChanged());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void AcknowledgedEmergency()
        {
            this.PlayerData.isEmergency = false;
            InvokeAsync(() => StateHasChanged());
        }
    }
}