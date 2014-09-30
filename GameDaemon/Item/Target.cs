using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Item
{
    class Target
    {
        public string Name { get; set; }
        public Strategy DaemonStrategy { get; set; }

        public Target(string name, Strategy strategy){
            this.Name = name;
            this.DaemonStrategy = strategy;
        }
    }
}
