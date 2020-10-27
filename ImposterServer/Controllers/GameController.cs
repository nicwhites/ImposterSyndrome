using ImposterServer.GameModels;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImposterServer.Controllers
{
    public class GameController : IDisposable
    {
        public int GameId { get; }
        public HostController Host { get; internal set; }

        public bool _disposed = false;

        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public GameController(int id)
        {
            GameId = id;
            Host = new HostController(id);
        }

        public static void StartGame()
        {

        }
        public void RestartGame()
        {

            throw new NotImplementedException();
        }
        public void ExitGame()
        {
            this.Dispose();           
        }

        //Disposal
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Host.Dispose();
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }

    }
}
