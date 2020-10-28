using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImposterServerInstance.Data.Controllers
{
    public class NotificationSystem
    {
            public bool isEmergencyCalled { get; private set; }
            public string WhistleBlower { get; private set; }

            public event Action OnChange;

            public void Emergency(string name)
            {
                WhistleBlower = name;
                isEmergencyCalled = true;
                NotifyStateChanged();
            }

           private void NotifyStateChanged() => OnChange?.Invoke();     
    }
}
