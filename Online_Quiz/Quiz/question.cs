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
        private int answer_1;
        private int answer_2;
        private int answer_3;
        private int answer_4;

        public int Question_id { get => question_id; set => question_id = value; }
        public string Quiz_question { get => quiz_question; set => quiz_question = value; }
        public int Answer_1 { get => answer_1; set => answer_1 = value; }
        public int Answer_2 { get => answer_2; set => answer_2 = value; }
        public int Answer_3 { get => answer_3; set => answer_3 = value; }
        public int Answer_4 { get => answer_4; set => answer_4 = value; }

        public question(int question_id, string quiz_question, int answer_1, int answer_2, int answer_3, int answer_4)
        {
            this.question_id = question_id;
            this.quiz_question = quiz_question;
            this.answer_1 = answer_1;
            this.answer_2 = answer_2;
            this.answer_3 = answer_3;
            this.answer_4 = answer_4;
        }
    }
}
