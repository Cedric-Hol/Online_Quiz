using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Quiz.style
{
    public class menu
    {
        public static void startMenu()
        {
            Console.WriteLine("Welcome to the quiz menu!\r\n");
            Console.WriteLine("1) Make a account.");
            Console.WriteLine("2) Start a quiz.");
            Console.WriteLine("3) Make a quiz.");
            Console.WriteLine("4) Exit.");
            Console.Write("\r\nWhat would you like to do?:");
            int answer = Console.Read();

            switch (answer)
            {
                
            }
        }
    }
}
