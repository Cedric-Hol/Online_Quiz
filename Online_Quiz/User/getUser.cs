using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.User
{
    public class getUser
    {
        public List<user> getUserInfoByUsernname(string username)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            string query = "SELECT `user_ID`, `username` FROM `users` WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            List<user> userInfo = new List<user>();
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user userFromdb = new user();
                        userFromdb.Id = reader.GetInt32(reader.GetOrdinal("user_ID"));
                        userFromdb.Username = reader.GetString(reader.GetOrdinal("username"));
                        userInfo.Add(userFromdb);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return userInfo;
        }
    }
}