using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace GameDaemon.Dao
{
    class TargetDao
    {
        private static TargetDao instance = new TargetDao();

        public static TargetDao getInstance()
        {
            return instance;
        }

        private TargetDao()
        {
   
        }
    }
}
