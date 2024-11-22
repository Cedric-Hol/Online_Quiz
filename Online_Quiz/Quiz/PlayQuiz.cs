using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using Online_Quiz.style;
using Online_Quiz.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Quiz.Quiz
{
    public class PlayQuiz
    {
        menu menuClass = new menu();
        addQuestions quizList = new addQuestions();
        public int score = 0;
        public void PlayQuizMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to play?");
            Console.WriteLine("1) Play a quiz.");
            Console.WriteLine("2) Exit to menu");
            Console.Write("Your choice: ");
            string answer = Console.ReadLine();

            //Bowdy:
            //Kan checken of wat er ingevuld is letters heeft, anders komt er een error
            //if (int.TryParse(answer, out int result))
            //Als dit true returned is het een getal
            //Cedric: het is inderdaad een fijne manier maar er mocht wel een klein beetje meer uitleg bij
            if (int.TryParse(answer, out int result)) 
            {
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        showQuizIdAndName();
                        Console.Write("What quiz would you like to play?: ");
                        int quizID = Convert.ToInt32(Console.ReadLine());
                        ShowQuestions(quizID);
                        break;
                    case 2:
                        menuClass.showMenu();
                        break;
                    default:
                        Console.WriteLine("Please Select one of the options.");
                        Thread.Sleep(2000);
                        PlayQuizMenu();
                        break;
                }
            }
            else
            {
                PlayQuizMenu();
            }
        }

        public List<question> PlayChosenQuiz(int quizID)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            string query = "SELECT * FROM questions WHERE quizID = @quizID";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());
            command.Parameters.AddWithValue("@quizID", quizID);
            List<question> questionList = new List<question>();
            try
            {
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        question question = new question(
                            reader.GetString(reader.GetOrdinal("question")),
                            reader.GetString(reader.GetOrdinal("answer_1")),
                            reader.GetString(reader.GetOrdinal("answer_2")),
                            reader.GetString(reader.GetOrdinal("answer_3")),
                            reader.GetString(reader.GetOrdinal("answer_4")),
                            reader.GetInt32(reader.GetOrdinal("correct_Answer"))
                            );
                        questionList.Add(question);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return questionList;
        }

        public void ShowQuestions(int quizID)
        {
            //Bowdy: Menu's zoals dit worden vaak herhaald. Menus zoals deze en de functie ShowMenu in menu.cs en addQuestionmenu in addQuestions.cs lijken best op elkaar.
            //Zou het mogelijk zijn om die menu's in 1 functie te zetten?

            Console.Clear();
            List<question> listQuestion = PlayChosenQuiz(quizID);

            foreach (question question in listQuestion)
            {
                Console.Clear();
                Console.WriteLine(question.Quiz_question);
                Console.WriteLine("1. " + question.Answer_1);
                Console.WriteLine("2. " + question.Answer_2);
                Console.WriteLine("3. " + question.Answer_3);
                Console.WriteLine("4. " + question.Answer_4);
                Console.Write("What is the answer (1-4)?: ");
                int answer;
                while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
                {
                    Console.Write("Invalid input. Please enter a number between 1 and 4: ");
                }
                if (answer == question.Correct_answer)
                {
                    score++;
                }
                Console.Write($"Your current score is: {score} press any key to continue!");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine($"Congratulations you completed the quiz! your score was {score}");
            Console.Write("Press any key to continue");
            Console.ReadKey();
            PlayQuizMenu();
        }

        private List<quiz> getQuizInfo()
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            string query = "SELECT * FROM quiz";
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
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

        private void showQuizIdAndName()
        {
            List<quiz> quizzes = getQuizInfo();
            foreach (quiz Quiz in quizzes)
            {
                Console.WriteLine($"{Quiz.QuizID} - {Quiz.QuizName}");
            }
        }
    }
}
