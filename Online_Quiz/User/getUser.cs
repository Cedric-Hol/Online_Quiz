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
        public List<user> getUserInfo(string username)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            string query = "SELECT * FROM users WHERE username = @username";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@username", username);
            List<user> userData = new List<user>();
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user user = new user(
                            reader.GetInt32(reader.GetOrdinal("user_ID")),
                            reader.GetString(reader.GetOrdinal("username"))
                            );
                        userData.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return userData;
        }

        public string getUsername(string username)
        {
            List<user> users = getUserInfo(username);
            foreach (user User in users)
            {
                return User.Username;
            }
            return "No User Found";
        }

        public int getUserId(string username)
        {
            List<user> users = getUserInfo(username);
            foreach (user User in users)
            {
                return User.Id;
            }
            return 0;
        }
    }
}