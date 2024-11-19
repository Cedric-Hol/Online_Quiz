using MySql.Data.MySqlClient;
using Online_Quiz.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.Quiz
{
    public class DeleteQuiz
    {
        public void deleteQuiz(int quizID)
        {
            DatabaseConnect db = DatabaseConnect.GetInstance();
            try
            {
                string query = "DELETE FROM `quiz` WHERE quizID = (@quizID)";
                using (MySqlCommand command = new MySqlCommand(query, db.GetConnection()))
                {
                    command.Parameters.AddWithValue("quizID", quizID);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
