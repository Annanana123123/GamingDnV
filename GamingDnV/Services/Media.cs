using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamingDnV.Services
{
    public class Media
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwdCallBack);
        
        public void Open(string file)
        {
            string Format = @"open ""{0}"" type MPEGVideo alias MediaFile";
            string command = string.Format(Format, file);
            mciSendString(command, null, 0, 0);
        }
        public void Play()
        {
            string command = "play MediaFile";
            mciSendString(command, null, 0, 0);
        }
        public void Stop()
        {
            string command = "stop MediaFile";
            mciSendString(command, null, 0, 0);
            ClosePlayer();
        }
        private void ClosePlayer()
        {
                String command = "Close MediaFile";
                mciSendString(command, null, 0, 0);
        }
    }
}
