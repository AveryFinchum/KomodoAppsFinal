using _KomodoClaims;
using KomodoMenuConsole;
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


        private readonly KomodoClaimsRepo _claimsRepo = new KomodoClaimsRepo();

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

        //*************************************MENU METHODS**************************************
        //List all in order
        /*
        private void ListAllMeals()
        {
            //get all items in menu repo
            List<MenuItem> item = _menuRepo.GetMenuItems();
            if (item.Count != 0)
            {
                foreach (MenuItem meal in item)
                {
                    DisplayContent(meal);
                }
            }
            else
            {
                Console.WriteLine("There are no meals to list");
            }
            AnyKey();
        }
        //List all of one meal number(ideally this will list only one meal)
        private void GetMealBynumber()
        {
            Console.Write("Enter a meal number: ");
            // Capture number
            int number = int.Parse(Console.ReadLine());
            // Look up content
            List<MenuItem> item = _menuRepo.GetMenuItem(number);
            if (item.Count != 0)
            {
                foreach (MenuItem meal in item)
                {
                    DisplayContent(meal);
                }
            }
            else
            {
                Console.WriteLine("Couldn't find a meal by that number");
            }
            AnyKey();
        }
        */

        //Add
        private void AddMeal()
        {
            //Console.Clear(); 
            KomodoClaim tempClaim = new KomodoClaim();

            // Claim Number
            Console.Write("Please enter a Claim ID Number: ");
            tempClaim.ClaimID = int.Parse(Console.ReadLine());

            // Claim Type
            Console.Write("Please enter a Claim Type from one of the following:\n" +
                          " 1. Car\n" +
                          " 2. Home\n" +
                          " 3. Theft\n");
            tempClaim.ClaimType = (KomodoClaim.ClaimTypes)int.Parse(Console.ReadLine());

            // Claim Description
            Console.Write("Please enter the Claim's Description: ");
            tempClaim.Description = Console.ReadLine();

            // Claim Amount
            Console.Write("Please enter the Claim's dollar amount: ");
            tempClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            // Date of incident
            Console.Write("Please enter the date the incident occured: ");
            tempClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());
            
            // Date of Claim 
            Console.Write("Please enter the date the claim was made: ");
            tempClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("");

            if (_claimsRepo.AddItemToClaims(tempClaim))
            {
                Console.WriteLine("Success!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Failure!");
                AnyKey();
            }
        }

        //************************************HELPER METHODS*************************************
        private void DisplayClaim(KomodoClaim claim)
        {
            Console.WriteLine("" +
               $"Claim ID:         {claim.ClaimID}\n" +
               $"Claim Type:       {claim.ClaimType}\n" +
               $"Description:      {claim.Description}\n" +
               $"Claim Amount:     {claim.ClaimAmount}\n" +
               $"Date of Incident: {claim.DateOfIncident}\n" +
               $"Date of Claim:    {claim.DateOfClaim}\n" +
               $"Valid Claim:      {claim.IsValid}\n" +
               "");
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
