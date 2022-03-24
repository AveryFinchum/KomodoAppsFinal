using _KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _KomodoClaimsMenuConsole
{
    internal class KomodoClaimsConsoleUI
    {


        //private readonly KomodoCafeMenuRepo _menuRepo = new KomodoCafeMenuRepo();

        internal void Run()
        {
            ConsoleWelcomeScreen();
            MainMenuLoop();
            Goodbye();
        }

        private void MainMenuLoop()
        {

            bool mainMenu = true;
            while (mainMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Claims Management App! \n" +
                    "Would you like to: \n" +
                    "1. `V`iew all Claims \n" +
                    "2. `T`ake care of Next claim \n" +
                    "3. Enter a `N`ew Claim \n" +
                    "4. `E`xit Application");
                   // "4. Delete an existing Claim\n" +


                string userInput = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                    case "v":
                        //ViewAllClaims();
                        break;
                    case "2":
                    case "t":
                        //TakeCareOfNextClaim();
                        break;
                    case "3":
                    case "n":
                        //NewClaim();
                        break;
                    case "4":
                    case "exit":
                    case "e":
                        mainMenu = false;
                        break;
                    
                    /*case "5":
                    case "d":
                        //DeleteClaimByID();
                        break;
                    */
                }
            }
        }



        //************************************HELPER METHODS*************************************
        private void DisplayContent(KomodoClaim item)
        {
            Console.WriteLine("" +
               $"Meal Number: {item.ClaimID}\n" +
               $"Name:        {item.ClaimType}\n" +
               $"Description: {item.Description}\n" +
               $"Ingredients: {item.DateOfIncident}\n" +
               $"Price:       {item.ClaimAmount}\n");
        }
        private void ConsoleWelcomeScreen()
        {
            string welcomeScreen = @"
██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗     ██████╗██╗      █████╗ ██╗███╗   ███╗███████╗
██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗   ██╔════╝██║     ██╔══██╗██║████╗ ████║██╔════╝
█████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║   ██║     ██║     ███████║██║██╔████╔██║███████╗
██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║   ██║     ██║     ██╔══██║██║██║╚██╔╝██║╚════██║
██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝   ╚██████╗███████╗██║  ██║██║██║ ╚═╝ ██║███████║
╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝     ╚═════╝╚══════╝╚═╝  ╚═╝╚═╝╚═╝     ╚═╝╚══════╝
                                                                                                         
";

            void drawSplash()
            {
                foreach (char l in welcomeScreen)
                {
                    Thread.Sleep(1);
                    Console.Write(l);
                }
                Console.WriteLine();
            }

            drawSplash();
            Thread.Sleep(1200);
            //AnyKey();

        }
        private void Goodbye()
        {
            string GoodbyeScreen = @"
 ██████╗  ██████╗  ██████╗ ██████╗     ██████╗ ██╗   ██╗███████╗██╗
██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗    ██╔══██╗╚██╗ ██╔╝██╔════╝██║
██║  ███╗██║   ██║██║   ██║██║  ██║    ██████╔╝ ╚████╔╝ █████╗  ██║
██║   ██║██║   ██║██║   ██║██║  ██║    ██╔══██╗  ╚██╔╝  ██╔══╝  ╚═╝
╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝    ██████╔╝   ██║   ███████╗██╗
 ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝     ╚═════╝    ╚═╝   ╚══════╝╚═╝
                                                                   ";

            void drawSplash()
            {
                foreach (char l in GoodbyeScreen)
                {
                    //Thread.Sleep(1);
                    Console.Write(l);
                }
                Console.WriteLine();
            }

            drawSplash();
            Thread.Sleep(1200);

        }
        private void AnyKey()
        {
            Thread.Sleep(600);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
