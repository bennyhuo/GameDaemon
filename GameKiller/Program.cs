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
            while (true)
            {
                Process[] procs = Process.GetProcessesByName("QQGameHall");
                foreach(Process p in procs){
                    p.Kill();
                    Console.WriteLine("kill ...");
                }
                Thread.Sleep(10000);
                Console.WriteLine("again ...");
            }
        }
    }
}
