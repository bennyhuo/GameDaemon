using GameDaemon.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Xceed.Wpf.Toolkit;

namespace GameDaemon.Item
{
    class Controller
    {
        private static Controller instance = new Controller();
        public static Controller getInstance()
        {
            return instance;
        }

        private Controller()
        {
            targets = TargetDao.getInstance().getTargets();
        }

        private List<Target> targets;

        public List<Target> Targets
        {
            get
            {
                return targets;
            }
        }

        public void addTarget(Target t)
        {
            targets.Add(t);
            TargetDao.getInstance().insertTarget(t);
        }

        public void rmTarget(int index)
        {
            TargetDao.getInstance().rmTarget(targets.ElementAt(index));
            targets.RemoveAt(index);
        }

        BackgroundWorker worker;
        Dispatcher dispatcher;

        public void startDaemon()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(DoWorkImpl);
            dispatcher = Dispatcher.CurrentDispatcher;
            if (dispatcher != null)
            {
                worker.RunWorkerAsync();
            }
        }

        public void stopDaemon()
        {
            worker.CancelAsync();
        }

        private void DoWorkImpl(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                List<Target> targetsTmp = this.targets;
                foreach (Target target in targetsTmp)
                {
                    Process[] procs = Process.GetProcessesByName(target.Name);
                    if (!target.DaemonStrategy.isAvailable())
                    {
                        foreach (Process p in procs)
                        {
                            p.Kill();
                            Console.WriteLine(p.ProcessName);
                            dispatcher.Invoke(DispatcherPriority.SystemIdle, new DelegateMessage(ShowMessage),p.ProcessName+"已经被干掉了！让你丫不务正业！");
                        }
                    }
                }
                Thread.Sleep(10000);
            }
        }

        private delegate void DelegateMessage(String text);

        private void ShowMessage(String text)
        {
            MessageBox.Show(text, "玩啊，有本事你接着玩啊！");
        }
    }
}
