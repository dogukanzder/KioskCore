using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KioskCore
{
    public static class WindowHelper
    {
        public static void BringProcessToFront(Process process)
        {
            try
            {
                IntPtr handle = process.MainWindowHandle;
                if (IsIconic(handle))
                    ShowWindow(handle, SW_RESTORE);

                SetForegroundWindow(handle);
            }
            catch (Exception ex)
            {
                if (KioskCoreTaskTray.saveLog)
                    KioskCoreTaskTray.LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
        }

        const int SW_RESTORE = 9;

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
    }
}
