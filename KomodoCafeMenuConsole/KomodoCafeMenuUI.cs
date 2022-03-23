using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KomodoCafeMenuConsole
{
    internal class KomodoCafeMenuUI
    {
        internal void Run()
        {
            ConsoleWelcomeScreen();
            MainMenuLoop();
        }

        //************************************HELPER FUNCTIONS*************************************
        private void ConsoleWelcomeScreen()
        {
            string welcomeScreen = @"
██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗      ██████╗ █████╗ ███████╗███████╗
██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗    ██╔════╝██╔══██╗██╔════╝██╔════╝
█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║    ██║     ███████║█████╗  █████╗  
██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║    ██║     ██╔══██║██╔══╝  ██╔══╝  
██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝    ╚██████╗██║  ██║██║     ███████╗
╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝      ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝
                                                                                                                                                 
";

            void drawSplash()
            {
                foreach (char l in welcomeScreen)
                {
                    //Thread.Sleep(1);
                    Console.Write(l);
                }
                Console.WriteLine();
            }

            drawSplash();
            AnyKey();

        }

        private void AnyKey()
        {
            Thread.Sleep(600);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void MainMenuLoop()
        {

            bool mainMenu = true;
            while (mainMenu)
            {
                Console.Clear();
                Console.Write("Welcome to Komodo Cafe Management App \n" +
                    "Would you like to:" +
                    "1. View all Meal types \n" +
                    "2. Add a new meal \n" +
                    "3. Delete an existing meal\n " +
                    "4. Exit Application");

                string userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                        //ListAllMeals();
                        break;
                    case "2":
                        //AddMeal();
                        break;
                    case "3":
                        //DeleteMeal();
                        break;
                    case "4":
                    case "exit":
                    case "e":
                        mainMenu = false;
                        break;

                }

}
        }

    }
}
