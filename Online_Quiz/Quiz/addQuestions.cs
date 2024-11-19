using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using Online_Quiz.style;
using Online_Quiz.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private DeleteQuiz deleteQuiz = new DeleteQuiz();
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
                    Console.Clear();
                    showQuizIdAndName(username);
                    Console.Write("To What quiz do you want to add a question?: ");
                    int questionID = Convert.ToInt32(Console.ReadLine());
                    AddQuestionQuestions(questionID);
                    addQuestionMenu(username);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("What quiz would you like to delete?");
                    showQuizIdAndName(username);
                    Console.Write("Wich would you like to delete?: ");
                    int quizID = Convert.ToInt32(Console.ReadLine());
                    deleteQuiz.deleteQuiz(quizID);
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

        public List<quiz> getQuizInfo(string username)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            int id = GetUser.getUserId(username);
            string query = "SELECT * FROM quiz WHERE user_ID = @id";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@id", id);
            List<quiz> quizData = new List<quiz>();
            try
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quiz quiz = new quiz(
                            reader.GetInt32(reader.GetOrdinal("quizID")),
                            reader.GetString(reader.GetOrdinal("quizName"))
                            );
                        quizData.Add(quiz);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return quizData;
        }

        public void showQuizIdAndName(string username)
        {
            List<quiz> quizzes = getQuizInfo(username);
            foreach(quiz Quiz in quizzes)
            {
                Console.WriteLine($"{Quiz.QuizID} - {Quiz.QuizName}");
            }
        }

        public void AddQuestion(int quizID, question question)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            try
            {
                string query = "INSERT INTO `questions` (`quizID`, `question`, `answer_1`, `answer_2`, `answer_3`, `answer_4`, `correct_Answer`) " +
                                       "VALUES (@quizID, @question, @answer_1, @answer_2, @answer_3, @answer_4, @correct_Answer)";

                using (MySqlCommand command = new MySqlCommand(query, db.GetConnection()))
                {
                    command.Parameters.AddWithValue("@quizID", quizID);
                    command.Parameters.AddWithValue("question", question.Quiz_question);
                    command.Parameters.AddWithValue("answer_1", question.Answer_1);
                    command.Parameters.AddWithValue("answer_2", question.Answer_2);
                    command.Parameters.AddWithValue("answer_3", question.Answer_3);
                    command.Parameters.AddWithValue("answer_4", question.Answer_4);
                    command.Parameters.AddWithValue("correct_Answer", question.Correct_answer);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void AddQuestionQuestions(int quizID)
        {
            question question = new question();
            Console.Write("What is the question?: ");
            question.Quiz_question = Console.ReadLine();
            Console.Write("What is the first answer?: ");
            question.Answer_1 = Console.ReadLine();
            Console.Write("What is the second answer?: ");
            question.Answer_2 = Console.ReadLine();
            Console.Write("What is the third answer?: ");
            question.Answer_3 = Console.ReadLine();
            Console.Write("What is the forth answer?: ");
            question.Answer_4 = Console.ReadLine();
            Console.Write("What is the correct answer?: ");
            question.Correct_answer = Console.ReadLine();
            AddQuestion(quizID, question);
        }
    }
}
