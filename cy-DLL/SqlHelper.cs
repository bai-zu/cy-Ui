using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cy_DLL
{
    public static class SqlHelper
    {
        static MySqlConnection connection;
        static MySqlCommand command;
        static string connstr = "server=127.0.0.1;database=zy;username=root;password=2326;";
        //增删改
        public static int AddDeleteAndModify(string sql)
        {
            int a = 0;
            using (connection = new MySqlConnection(connstr))
            {

                using (command = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    a = command.ExecuteNonQuery();
                }

            }
            return a;
        }
        //查询
        public static MySqlDataReader Query(string sql)
        {
            MySqlDataReader mySqlDataReader;
            connection = new MySqlConnection(connstr);

            command = new MySqlCommand(sql, connection);

            connection.Open();
            mySqlDataReader = command.ExecuteReader();
            //connection.Close();
            return mySqlDataReader;
        }
        
        public static int OnlyQuery(string sql)
        {
            using (MySqlConnection connection = new MySqlConnection(connstr))
            {

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    connection.Open();

                }

            }
            return 0;
        }
        //生成唯一id（string类型）
        public static string GetOID()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
        //生成唯一id（long类型）
        public static long GetNumberOID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

    }
}
