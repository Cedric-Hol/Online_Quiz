using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using Online_Quiz.style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Quiz.User
{
    public class addUser
    {
        public void addUserMenu()
        {
            menu menuClass = new menu();
            Console.Clear();
            int answer = 0;
            Console.WriteLine("Welkom to the account menu.\r\n");
            Console.WriteLine("1) Make a account.");
            Console.WriteLine("2) Exit.");

            Console.Write("\r\nWhat would you like to do?:");
            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    Console.Write("What would you like your username to be?: ");
                    string username = Console.ReadLine();
                    addUserToDatabase(new user(username));
                    break;
                case 2:
                    Console.Clear();
                    menuClass.showMenu();
                    break;
                default:
                    Console.WriteLine("Please Select one of the options.");
                    Thread.Sleep(2000);
                    addUserMenu();
                    break;
            }
        }

        public void addUserToDatabase(user User)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            try
            {
                string query = "INSERT INTO `users`(`username`) VALUES (@username)";

                using (MySqlCommand command = new MySqlCommand(query, db.GetConnection()))
                {
                    command.Parameters.AddWithValue("@username", User.Username);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
