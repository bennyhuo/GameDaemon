using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] procs = Process.GetProcesses();//.GetProcessesByName("QQGameHall");
            foreach (Process p in procs)
            {
                //p.Kill();
                //Console.WriteLine("kill ...");
                Console.WriteLine(p.ProcessName);
            }
            //Thread.Sleep(10000);
            Console.WriteLine("again ...");
            Console.Read();
        }
    }
}
