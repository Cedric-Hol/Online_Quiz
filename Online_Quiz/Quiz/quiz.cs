using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.Quiz
{
    public class quiz
    {
        private int quizID;
        private string quizName;

        public int QuizID { get => quizID; set => quizID = value; }
        public string QuizName { get => quizName; set => quizName = value; }

        public quiz(int quizID, string quizName)
        {
            this.quizID = quizID;
            this.quizName = quizName;
        }
    }
}
