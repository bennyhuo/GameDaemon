using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Dao
{
    class StrategyDao
    {
        private static StrategyDao instance = new StrategyDao();

        public static  StrategyDao getInstance()
        {
            return instance;
        }

        private StrategyDao()
        {

        }


    }
}
