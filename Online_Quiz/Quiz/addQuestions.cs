using Online_Quiz.style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

                switch (answer)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        Console.Clear();
                        menu.startMenu();
                        break;
                    default:
                        Console.WriteLine("Please Select one of the options.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
    }
}
