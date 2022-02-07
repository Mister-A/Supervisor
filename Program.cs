using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Supervisor
{
    public class Program
    {
        private static void Main(string[] args)
        {
            MonitorSettings settings = new MonitorSettings();
            var threads = new List<MonitorThread>(settings.monitorGroup.Monitors.Count);

            foreach (MonitorGroup.ApplicationElement appMonitor in settings.monitorGroup.Monitors)
            {
                var t = new MonitorThread(appMonitor);
                threads.Add(t);
            }
            Thread.Sleep(5000);
            for (int i = 0; i < threads.Count; i++)
            {
                threads[i].IsCancelled = true;
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
                }
                if (IsCancelled)
                {
                    if (!Process.HasExited)
                    {
                        Process.Kill();
                        break;
                    }
                }
                //wait a bit to reduce resource overhead
                Thread.Sleep(2000);
            }
        }

        public void Stop()
        {
            IsCancelled = true;
        }

        public void Join()
        {
            if (Thread.IsAlive)
                Thread.Join();
        }

        public bool Join(TimeSpan timeout)
        {
            if (Thread.IsAlive)
                return Thread.Join(timeout);
            else
                return true;
        }
    }
}