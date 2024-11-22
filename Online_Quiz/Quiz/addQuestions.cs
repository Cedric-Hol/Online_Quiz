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
            //Bowdy: Menu's zoals dit worden vaak herhaald. Menus zoals deze en de functie ShowMenu in menu.cs en ShowQuestions in PlayQuiz.cs lijken best op elkaar.
            //Zou het mogelijk zijn om die menu's in 1 functie te zetten?
            //Cedric:Deze had ik inderdaad beter in een class kunnen doen. maar het is niet echt herhalende informatie.
            Console.Clear();
            menu menuClass = new menu();
            Console.WriteLine("Welcome to the make a quiz menu!\r\n");
            Console.WriteLine("1) Make a quiz.");
            Console.WriteLine("2) Add questions to a Quiz");
            Console.WriteLine("3) Delete a quiz.");
            Console.WriteLine("4) Exit.");
            Console.Write("\r\nWhat would you like to do?:");
            string answer = Console.ReadLine();


            //Bowdy:
            //Kan checken of wat er ingevuld is letters heeft, anders komt er een error
            //if (int.TryParse(answer, out int result))
            //Als dit true returned is het een getal
            if (int.TryParse(answer, out int result))
            {
                switch (result)
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
                        AddQuestionAnswers(questionID);
                        addQuestionMenu(username);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What quiz would you like to delete?");
                        showQuizIdAndName(username);
                        Console.Write("Which would you like to delete?: ");
                        int quizID = Convert.ToInt32(Console.ReadLine());
                        deleteQuiz.deleteQuiz(quizID);
                        break;
                    case 4:
                        menuClass.showMenu();
                        break;
                    default:
                        Console.WriteLine("Please Select one of the options. Press any key to continue..");
                        //Bowdy: Thread.Sleep is niet handig want hij leest nog steeds wat er getypt wordt, alleen wordt het niet laten zien.
                        //Het zou better zijn als de thread sleep helemaal weggehaald wordt
                        Console.ReadKey();
                        addQuestionMenu(username);
                        break;
                }
            }
            else
            {
                addQuestionMenu(username);
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
                    command.Parameters.AddWithValue("answer_1", $"1) - {question.Answer_1}");
                    command.Parameters.AddWithValue("answer_2", $"2) - {question.Answer_2}");
                    command.Parameters.AddWithValue("answer_3", $"3) - {question.Answer_3}");
                    command.Parameters.AddWithValue("answer_4", $"4) - {question.Answer_4}");
                    command.Parameters.AddWithValue("correct_Answer", question.Correct_answer);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Bowdy: Ik vind de naamgeving niet helemaal duidelijk hier, ik zou zelf "AddQuestionAnswers" duidelijker vinden.
        //Cedric: Ik ben het helemaal mee eens
        public void AddQuestionAnswers(int quizID)
        {
            Console.Clear();
            question question = new question();
            Console.Write("What is the question?: ");
            question.Quiz_question = Console.ReadLine();
            Console.Write("What is the first answer?: ");
            question.Answer_1 = Console.ReadLine();
            Console.Write("What is the second answer?: ");
            question.Answer_2 = Console.ReadLine();
            Console.Write("What is the third answer?: ");
            question.Answer_3 = Console.ReadLine();
            Console.Write("What is the fourth answer?: ");
            question.Answer_4 = Console.ReadLine();
            Console.Write("What is the correct answer 1/2/3/4?: ");
            question.Correct_answer = Convert.ToInt32(Console.ReadLine());
            AddQuestion(quizID, question);
        }
    }
}
