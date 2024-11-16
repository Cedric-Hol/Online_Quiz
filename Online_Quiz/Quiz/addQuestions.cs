using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using Online_Quiz.style;
using Online_Quiz.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Online_Quiz.Quiz
{
    public class addQuestions
    {
        private getUser GetUser = new getUser();
        public void addQuestionMenu(string username)
        {
            Console.Clear();
            menu menuClass = new menu();
            Console.WriteLine("Welcome to the make a quiz menu!\r\n");
            Console.WriteLine("1) Make a quiz.");
            Console.WriteLine("2) Add questions to a Quiz");
            Console.WriteLine("3) Delete a quiz.");
            Console.WriteLine("4) Exit.");
            Console.Write("\r\nWhat would you like to do?:");
            int answer;
            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    Console.Clear();
                    Console.Write("What would you like your quiz to be named?: ");
                    string quizName = Console.ReadLine();
                    MakeAQuiz(quizName, username);
                    addQuestionMenu(username);
                    break;
                case 2:
                    break;
                case 3:
                    
                    break;
                case 4:
                    menuClass.showMenu();
                    break;
                default:
                    Console.WriteLine("Please Select one of the options.");
                    Thread.Sleep(2000);
                    addQuestionMenu(username);
                    break;
            }
        }

        public void MakeAQuiz(string quizName, string username)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            try
            {
                int user_ID = GetUser.getUserId(username);
                string query = "INSERT INTO quiz (quizName, user_ID) VALUES (@quizName, @user_ID)";
                using (MySqlCommand command = new MySqlCommand(query, db.GetConnection()))
                {
                    command.Parameters.AddWithValue("quizName", quizName);
                    command.Parameters.AddWithValue("user_ID", user_ID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddQuestion(string username)
        {

        }
    }
}
