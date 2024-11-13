using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.Quiz
{
    public class addQuestions
    {
        public static void addQuestionMenu()
        {
            while (true)
            {
                int answer;
                Console.Clear();
                Console.WriteLine("Welcome to the make a quiz menu!\r\n");
                Console.WriteLine("1) Make a quiz.");
                Console.WriteLine("2) Delete a quiz.");
                Console.WriteLine("3) Exit.");
                Console.Write("\r\nWhat would you like to do?:");
                answer = Convert.ToInt32(Console.ReadLine());

                
            }
        }
    }
}
