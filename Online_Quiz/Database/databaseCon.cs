using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Online_Quiz
{
    public class databaseCon
    {
        public class databaseConnect
        {
            private static databaseConnect _databaseConnect = null;

            private readonly string mySqlCon = "server=localhost; user=root; database=online_quiz; password=";

            private MySqlConnection mySqlConnection;

            private databaseConnect()
            {
                try
                {
                    mySqlConnection = new MySqlConnection(mySqlCon);
                    mySqlConnection.Open();
                    Console.WriteLine("Database connection established");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public MySqlConnection GetConnection()
            {
                return mySqlConnection;
            }

            public static databaseConnect GetInstance()
            {
                if (_databaseConnect == null)
                {
                    _databaseConnect = new databaseConnect();
                }
                return _databaseConnect;
            }

            public void CloseConnection()
            {
                if (mySqlConnection != null && mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    mySqlConnection.Close();
                    Console.WriteLine("close connection");
                }
            }

            public static void openConnection()
            {
                databaseConnect db = databaseConnect.GetInstance();
                MySqlConnection conn = db.GetConnection();
                Console.Clear();
            }
        }
    }
}
