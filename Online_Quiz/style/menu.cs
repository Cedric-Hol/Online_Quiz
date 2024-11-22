using Online_Quiz.Quiz;
using Online_Quiz.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Online_Quiz.style
{
    public class menu
    {
        public void showMenu()
        {
            Console.Clear();
            addQuestions questionMenu = new addQuestions();
            addUser userMenu = new addUser();
            getUser GetUser = new getUser();
            PlayQuiz playQuiz = new PlayQuiz();
            Console.WriteLine("Welcome to the quiz menu!\r\n");
            Console.WriteLine("1) Make a account.");
            Console.WriteLine("2) Play a quiz.");
            Console.WriteLine("3) Make a quiz.");
            Console.WriteLine("4) Exit.");
            Console.Write("\r\nWhat would you like to do?:");
            string answer = Console.ReadLine();

            //Bowdy:
            //Kan checken of wat er ingevuld is letters heeft
            //if (int.TryParse(answer, out int result))
            //Als dit true returned is het een getal

            if (int.TryParse(answer, out int result))
            {
                switch (result)
                {
                    case 1:
                        userMenu.addUserMenu();
                        Console.WriteLine("User made.... returning to main menu.");
                        Thread.Sleep(2000);
                        showMenu();
                        break;
                    case 2:
                        Console.Clear();
                        playQuiz.PlayQuizMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("What is your username?: ");
                        string username = Console.ReadLine();
                        if (GetUser.getUsername(username) == username)
                        {
                            questionMenu.addQuestionMenu(username);
                        }
                        break;
                    case 4:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Please Select one of the options. Press any key to continue..");

                        //Bowdy: Thread.Sleep is niet handig want hij leest nog steeds wat er getypt wordt, alleen wordt het niet laten zien.
                        //Het zou better zijn als de thread sleep helemaal weggehaald wordt
                        Console.ReadKey();
                        showMenu();
                        break;
                }
            }
            else
            {
                showMenu();
            }
        }
    }
}
