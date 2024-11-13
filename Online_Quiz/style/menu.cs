using Online_Quiz.Quiz;
using Online_Quiz.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.style
{
    public class menu
    {
        public static void startMenu()
        {
            bool keepLoopGoing = true;
            while (keepLoopGoing)
            {
                Console.WriteLine("Welcome to the quiz menu!\r\n");
                Console.WriteLine("1) Make a account.");
                Console.WriteLine("2) Start a quiz.");
                Console.WriteLine("3) Make a quiz.");
                Console.WriteLine("4) Exit.");
                Console.Write("\r\nWhat would you like to do?:");
                int answer = Convert.ToInt32(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        addUser.addUserMenu();
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        addQuestions.addQuestionMenu();
                        break;
                    case 4:
                        Environment.Exit(-1);
                        keepLoopGoing = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
