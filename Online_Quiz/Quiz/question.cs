using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.Quiz
{
    public class question
    {
        private int question_id;
        private string quiz_question;
        private string answer_1;
        private string answer_2;
        private string answer_3;
        private string answer_4;
        private string correct_answer;

        public int Question_id { get => question_id; set => question_id = value; }
        public string Quiz_question { get => quiz_question; set => quiz_question = value; }
        public string Answer_1 { get => answer_1; set => answer_1 = value; }
        public string Answer_2 { get => answer_2; set => answer_2 = value; }
        public string Answer_3 { get => answer_3; set => answer_3 = value; }
        public string Answer_4 { get => answer_4; set => answer_4 = value; }
        public string Correct_answer { get => correct_answer; set => correct_answer = value; }

        public question()
        {

        }

        public question(string quiz_question, string answer_1, string answer_2, string answer_3, string answer_4, string correct_answer)
        {
            this.quiz_question = quiz_question;
            this.answer_1 = answer_1;
            this.answer_2 = answer_2;
            this.answer_3 = answer_3;
            this.answer_4 = answer_4;
            this.correct_answer = correct_answer;
        }
    }
}
