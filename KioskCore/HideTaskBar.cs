using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KioskCore
{
    internal class HideTaskBar
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
        private const int SW_HIDE = 0;
        
        public HideTaskBar()
        {
            try
            {
                int hwnd = FindWindow("Shell_TrayWnd", "");
                ShowWindow(hwnd, SW_HIDE);
            }
            catch (Exception ex)
            {
                if (KioskCoreTaskTray.saveLog)
                    KioskCoreTaskTray.LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
            
        }
    }
}
