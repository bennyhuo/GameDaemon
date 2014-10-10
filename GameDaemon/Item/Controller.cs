using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            targets = new List<Target>();
            targets.Add(new Target("abc", new Strategy()));
            targets.Add(new Target("bcd", new Strategy()));
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
        }

        public void rmTarget(int index)
        {
            targets.RemoveAt(index);
        }
                
    }
}
