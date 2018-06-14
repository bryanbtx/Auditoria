using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Auditoria
{
    class DataBase
    {
        public static int Comand(String command)
        {
            MySqlConnection conn = new MySqlConnection("Server=" + Constant.SERVER + ";Database=" + Constant.DATABASE + ";Uid=" + Constant.USER + ";Pwd=" + Constant.PASSWORD);
            MySqlCommand com = new MySqlCommand();
            try
            {
                com.CommandType = CommandType.Text;
                com.CommandText = command;
                com.Connection = conn;
                conn.Open();
                int n = com.ExecuteNonQuery();
                conn.Close();
                return n;
            }
            catch
            {
                return -1;
            }
        }

        public static DataTable Query(String command)
        {
            DataTable dataTable = new DataTable();
            MySqlConnection conn = new MySqlConnection("Server=" + Constant.SERVER + ";Database=" + Constant.DATABASE + ";Uid=" + Constant.USER + ";Pwd=" + Constant.PASSWORD);
            MySqlCommand com = new MySqlCommand();
            try
            {
                com.CommandType = CommandType.Text;
                com.CommandText = command;
                com.Connection = conn;
                conn.Open();
                dataTable.Load(com.ExecuteReader());
                conn.Close();
                return dataTable;
            }
            catch
            {
                return null;
            }
        }
    }
}
