using Supervisor.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Supervisor
{
    public class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SupervisorSysTray());
        }
    }

    public class SupervisorSysTray : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private List<MonitorThread> threads;
        private MonitorSettings settings = new MonitorSettings();

        public SupervisorSysTray()
        {
            threads = new List<MonitorThread>(settings.MonitorGroup.Monitors.Count);

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Text = "Supervisor program monitor",
                Icon = Resources.supervision,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Settings...", OpenSettings),
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            //Do our job
            Start();
        }

        //Tray icon menu item
        private void Exit(object sender, EventArgs e)
        {
            //Close anything we're responsible for starting
            Stop();

            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }

        //Tray icon menu item
        private void OpenSettings(object sender, EventArgs e)
        {
            Form settingsForm = new EditForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                Stop();
                Thread.Sleep(1000);
                //Force reload settings
                threads.Clear();
                settings = null;
                settings = new MonitorSettings();
                Start();
            }
        }

        //Start all defined monitors
        private void Start()
        {
            foreach (MonitorGroup.ApplicationElement appMonitor in settings.MonitorGroup.Monitors)
            {
                var t = new MonitorThread(appMonitor);
                threads.Add(t);
            }
        }

        //Signal monitors to stop and block until they've closed
        private void Stop()
        {
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Stop();
            }
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].Join();
            }
        }
    }

    public class MonitorThread
    {
        public readonly MonitorGroup.ApplicationElement Args;
        private readonly MonitorSettings settings = new MonitorSettings();
        private Alert alert = new Alert();

        public Process Process
        {
            get;
            private set;
        }

        public bool IsCancelled;

        private readonly Thread Thread;

        public MonitorThread(MonitorGroup.ApplicationElement monitor)
        {
            Args = monitor;
            Thread = new Thread(DoMonitor);
            Thread.Start();
        }

        private void DoMonitor()
        {
            Process = Process.Start(Args.Path, Args.Arguments);
            while (true)
            {
                if (Process.WaitForExit(1000) && !IsCancelled)
                {
                    Process = Process.Start(Args.Path, Args.Arguments);
                    //Raise an alert if set for this monitor
                    if (Args.Alert == "1")
                    {
                        alert.Send(Args.Path);
                    }
                }
                if (IsCancelled)
                {
                    if (!Process.HasExited)
                    {
                        Process.Kill();
                        break;
                    }
                }
                //Check interval
                Thread.Sleep(int.Parse(settings.FindSettingFromName("CheckPeriod").Value) * 1000);
            }
        }

        public void Stop()
        {
            IsCancelled = true;
        }

        public void Join()
        {
            if (Thread.IsAlive)
            {
                Thread.Join();
            }
        }

        public bool Join(TimeSpan timeout)
        {
            if (Thread.IsAlive)
            {
                return Thread.Join(timeout);
            }
            else
            {
                return true;
            }
        }
    }
}