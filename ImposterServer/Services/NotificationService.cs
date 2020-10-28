using System;
using System.Collections.Generic;
using System.Text;

namespace ImposterServer.Services
{
    public class NotificationService
    {
        public event Action trigger;
        public void notification() => trigger?.Invoke();
    }
}
