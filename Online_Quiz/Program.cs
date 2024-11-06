using MySql.Data.MySqlClient;
using Online_Quiz.style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Online_Quiz.databaseCon;

namespace Online_Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            databaseCon.databaseConnect.openConnection();
            menu.startMenu();
        }
    }
}
