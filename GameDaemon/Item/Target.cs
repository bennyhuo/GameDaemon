using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Item
{
    public class Target
    {
        public string Name { get; set; }
        public Strategy DaemonStrategy { get; set; }

        public Target(string name)
        {
            this.Name = name;
            this.DaemonStrategy = new Strategy();
        }

        public Target(string name, Strategy strategy){
            this.Name = name;
            this.DaemonStrategy = strategy;
        }

        override public string ToString()
        {
            return Name;
        }
    }
}
