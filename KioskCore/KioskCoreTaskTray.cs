using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace KioskCore
{
    public class KioskCoreTaskTray : ApplicationContext
    {
        public static string processPath;
        public static int closeHour;
        public static int closeMinute;
        public static int controlInterval;
        public static bool reopenProgram;
        public static bool saveLog;
        public static bool ctrlEscBlock;
        public static bool hideTaskBar;
        public static bool bringFront;

        public static bool newSettings;   

        public static string settingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\KioskCoreSettings.txt";

        public int processCount = 0;
        public bool exit = false;

        NotifyIcon notifyIcon;
        Configuration configWindow;

        Process p;

        System.Windows.Forms.Timer CloseTimer = new System.Windows.Forms.Timer();

        public KioskCoreTaskTray()
        {
            CloseTimer.Tick += new EventHandler(CloseTimer_Tick);

            BuildNotifyIcon();

            BuildConfigurationForm();
            
            if (ReadSettings())
            {
                AdjustWindows();

                AdjustProcess();

                RunProcess();
            }

            if (saveLog)
                LogEnter("CoreKioskOpen");
        }

        private void BuildNotifyIcon()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.KioskCore;
            notifyIcon.DoubleClick += new EventHandler(ShowConfig);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
        }

        private void BuildConfigurationForm()
        {
            configWindow = new Configuration();
            configWindow.FormClosed += (o, e) =>
            {
                if (!exit)
                {
                    if (newSettings)
                    {
                        AdjustWindows();

                        newSettings = false;
                    }
                    AdjustProcess();

                    RunProcess();
                }
            };
        }

        public bool ReadSettings()
        {
            try
            {
                if (File.Exists(settingsPath))
                {
                    newSettings = false;
                    string[] lines = File.ReadAllLines(settingsPath);
                    processPath = lines[0];
                    closeHour = Convert.ToInt16(lines[1]);
                    closeMinute = Convert.ToInt16(lines[2]);
                    controlInterval = Convert.ToInt16(lines[3]);
                    reopenProgram = lines[4] != "0";
                    saveLog = lines[5] != "0";
                    ctrlEscBlock = lines[6] != "0";
                    hideTaskBar = lines[7] != "0";
                    bringFront = lines[8] != "0";

                    return true;
                }
                else
                {
                    MessageBox.Show("Please configure settings.");
                    configWindow.ShowDialog();
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is an error in settings file, please reconfigure settings.");
                configWindow.ShowDialog();
                return false;
            }
        }

        private void AdjustWindows()
        {
            if (hideTaskBar)
                new HideTaskBar();
            if (ctrlEscBlock)
                new CtrlEscKeyBlock();
        }

        private void AdjustProcess()
        {
            try
            {
                CloseTimer.Interval = controlInterval * 60000;

                string processName = processPath.Split('\\').Last().Split('.')[0];

                if (Process.GetProcessesByName(processName).Length != 0)
                {
                    p = Process.GetProcessesByName(processName)[0];
                    p.EnableRaisingEvents = false;
                    p.Kill();
                }

                p = new Process();
                p.Exited += new EventHandler(ProcessExited);
                p.StartInfo.FileName = processPath;
                p.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                if (saveLog)
                    LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
            
            
        }

        void ProcessStart()
        {
            try
            {
                if (saveLog)
                    LogEnter(".processOpen");

                string processName = processPath.Split('\\').Last().Split('.')[0];
                if (Process.GetProcessesByName(processName).Length != 0)
                {
                    p = Process.GetProcessesByName(processName)[0];
                    p.EnableRaisingEvents = false;
                    p.Kill();
                }

                processCount++;
                p.Start();
                WindowHelper.BringProcessToFront(p);
            }
            catch (InvalidOperationException)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (saveLog)
                    LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
        }

        void ProcessExited(object sender, EventArgs e)
        {
            if (saveLog)
                LogEnter(".processExited");

            if (reopenProgram)
                ProcessStart();

        }

        private void RunProcess()
        {
            CloseTimer.Start();

            ProcessStart();
        }

        void CloseTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            if ((currentTime.Hours == closeHour && currentTime.Minutes >= closeMinute) || currentTime.Hours > closeHour)
                Shutdown();

            if (bringFront)
                WindowHelper.BringProcessToFront(p);
        }

        public void Shutdown()
        {
            try
            {
                CloseTimer.Stop();

                if (saveLog)
                    LogEnter("CoreKioskShutDown");

                p.EnableRaisingEvents = false;
                p.Kill();
                Thread.Sleep(3000);

                notifyIcon.Visible = false;
                Application.Exit(); 

                Thread.Sleep(3000);
                var psi = new ProcessStartInfo("shutdown", "/s /t 0")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                if (saveLog)
                    LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
        }

        static public void LogEnter(string log)
        {
            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\KioskCoreLog.txt", 
                               log + "\t\t\t-" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss") + "\n");
        }

        void ShowConfig(object sender, EventArgs e)
        {
            try
            {
                if (configWindow.Visible)
                    configWindow.Activate();
                else
                {
                    CloseTimer.Stop();
                    BuildConfigurationForm();
                    string processName = processPath.Split('\\').Last().Split('.')[0];

                    if (Process.GetProcessesByName(processName).Length != 0)
                    {
                        p = Process.GetProcessesByName(processName)[0];
                        p.EnableRaisingEvents = false;
                        p.Kill();
                    }

                    configWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                if (saveLog)
                    LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }
            
        }

        

        void Exit(object sender, EventArgs e)
        {
            exit = true;
            try
            {
                notifyIcon.Visible = false;

                string processName = processPath.Split('\\').Last().Split('.')[0];

                if (Process.GetProcessesByName(processName).Length != 0)
                {
                    p = Process.GetProcessesByName(processName)[0];
                    p.EnableRaisingEvents = false;
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                if (saveLog)
                    LogEnter("*error-" + ex.ToString() + "-" + ex.Message);
            }

            if (saveLog)
                LogEnter("KioskCoreClosed");

            Application.Exit();
        }
    }
}
