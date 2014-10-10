using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDaemon.Dao
{
    class DbConnection : IDisposable
    {
        private static DbConnection instance = new DbConnection();

        public static DbConnection getInstance()
        {
            return instance;
        }

        private SQLiteConnection conn;

        public SQLiteConnection getConn()
        {
            return conn;
        }

        private string datasource = "list.db";
        private DbConnection()
        {
            Console.WriteLine("init conn.");
            bool isFirstIn = !File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + datasource);
            initDatabase(isFirstIn);
        }

        private void initDatabase(bool isFirstIn)
        {
            
            if (isFirstIn)
            {
                SQLiteConnection.CreateFile(datasource);
            }
            conn = new SQLiteConnection();
            SQLiteConnectionStringBuilder connstr = new SQLiteConnectionStringBuilder();
            connstr.DataSource = datasource;
            connstr.Password = "admin";//设置密码，SQLite ADO.NET实现了数据库密码保护
            conn.ConnectionString = connstr.ToString();
            conn.Open();

            if (isFirstIn)
            {
                initTable();
            }
        }

        private void initTable()
        {
            SQLiteCommand cmd = new SQLiteCommand();
            string sql = "CREATE TABLE target(id integer primary key autoincrement, name varchar(255))";
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            string sql2 = "CREATE TABLE strategy(id integer primary key autoincrement, start integer, end integer, action integer, targetid integer)";
            cmd.CommandText = sql2;
            cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            conn.Dispose();
        }
    }
}
