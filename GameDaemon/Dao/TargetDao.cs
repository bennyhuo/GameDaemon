using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using GameDaemon.Item;
using System.Data;

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

        public List<Target> getTargets()
        {
            string sql = "select * from target";
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = DbConnection.getInstance().getConn();
            cmd.CommandText = sql;
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Target> ret = new List<Target>();
            while (reader.Read())
            {
                Target t = new Target(reader.GetInt32(0), reader.GetString(1));
                ret.Add(t);
            }

            cmd.Dispose();
            return ret;
        }

        public void insertTarget(Target t)
        {
            string sql = "insert into target(name) values(@NAME)";
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConnection.getInstance().getConn());
            SQLiteParameter param = new SQLiteParameter("@NAME", DbType.String);
            param.Value = t.Name;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select max(id) as id from target";
            cmd.Parameters.Clear();
            object id = cmd.ExecuteScalar();
            t.Id = Convert.ToInt32(id);

            cmd.Dispose();
        }

        public void rmTarget(Target t)
        {
            string sql = "delete from target where id=@ID";
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConnection.getInstance().getConn());
            SQLiteParameter param = new SQLiteParameter("@ID", DbType.Int32, 4);
            param.Value = t.Id;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

            StrategyDao.getInstance().rmActionItemByTargetId(t.Id);
            cmd.Dispose();
        }
    }
}
