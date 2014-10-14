using GameDaemon.Item;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Dao
{
    class StrategyDao
    {
        private static StrategyDao instance = new StrategyDao();

        public static StrategyDao getInstance()
        {
            return instance;
        }

        private StrategyDao()
        {

        }

        public List<ActionItem> getActionItems(int targetId)
        {
            string sql = "select id,sh,sm,eh,em,targetid from actionitem where targetid = @TARGET_ID";
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = DbConnection.getInstance().getConn();
            cmd.CommandText = sql;
            SQLiteParameter param = new SQLiteParameter("@TARGET_ID",DbType.Int32);
            param.Value = targetId;
            cmd.Parameters.Add(param);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<ActionItem> ret = new List<ActionItem>();
            while (reader.Read())
            {
                ActionItem item = new ActionItem(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
                item.TargetId = reader.GetInt32(5);
                ret.Add(item);
            }
            cmd.Dispose();
            return ret;
        }

        public void insertActionItem(ActionItem item)
        {
            string sql = "insert into actionitem(sh,sm,eh,em,targetid) values(@SH,@SM,@EH,@EM,@TARGET_ID)";
            SQLiteParameter[] param = {
                new SQLiteParameter("@SH",DbType.Int32,4),
                new SQLiteParameter("@SM",DbType.Int32,4),
                new SQLiteParameter("@EH",DbType.Int32,4),
                new SQLiteParameter("@EM",DbType.Int32,4),
                new SQLiteParameter("@TARGET_ID",DbType.Int32,4)
            };
            param[0].Value = item.startTimeValue / 60;
            param[1].Value = item.startTimeValue % 60;
            param[2].Value = item.endTimeValue / 60;
            param[3].Value = item.endTimeValue % 60;
            param[4].Value = item.TargetId;
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConnection.getInstance().getConn());
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();

            cmd.CommandText = "select max(id) as id from actionitem";
            cmd.Parameters.Clear();
            object id = cmd.ExecuteScalar();
            item.Id = Convert.ToInt32(id);
            cmd.Dispose();
        }

        public void rmActionItem(ActionItem item)
        {
            string sql = "delete from actionitem where id=@ID";
            SQLiteParameter param = new SQLiteParameter("@ID", DbType.Int32, 4);
            SQLiteCommand cmd = new SQLiteCommand(sql, DbConnection.getInstance().getConn());
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void rmActionItemByTargetId(int targetId)
        {
            string sql = "delete from actionitem where targetid=@TARGET_ID";
            SQLiteParameter param = new SQLiteParameter("@TARGET_ID", DbType.Int32);
            param.Value = targetId;

            SQLiteCommand cmd = new SQLiteCommand(sql, DbConnection.getInstance().getConn());
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
