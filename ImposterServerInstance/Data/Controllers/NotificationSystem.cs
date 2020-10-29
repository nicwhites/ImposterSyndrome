using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImposterServerInstance.Data.Controllers
{
    public class NotificationSystem
    {
            public string WhistleBlower { get; private set; }

            public event Action<string,int> OnChange;

            public void Emergency(string name, int GameId)
            {
                WhistleBlower = name;
                NotifyStateChanged(name,GameId);
            }

           private void NotifyStateChanged(string name, int id) => OnChange?.Invoke(name,id);     
    }
}
