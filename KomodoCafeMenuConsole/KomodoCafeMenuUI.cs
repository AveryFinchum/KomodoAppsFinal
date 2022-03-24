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
        private readonly MenuItem _menuRepo = new MenuItem();

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
                Console.WriteLine("Welcome to Komodo Cafe Meal Management App! \n" +
                    "Would you like to: \n" +
                    "1. View all meal types \n" +
                    "2. Add a new meal \n" +
                    "3. Delete an existing meal\n" +
                    "4. Exit Application");
                

                string userInput = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                    case "l":
                    case "v":
                        //ListAllMeals();
                        break;
                    case "2":
                    case "a":
                        //AddMeal();
                        break;
                    case "3":
                    case "d":
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


        //*************************************MENU METHODS**************************************

        private void AddMeal()
        {
            //Console.Clear(); 
            MenuItem tempMenuItem = new MenuItem();

            // Meal Number
            Console.Write("Please enter a Meal Number: ");
            tempMenuItem.Number = int.Parse(Console.ReadLine());

            // Name
            Console.Write("Please enter a Name: ");
            tempMenuItem.Name = Console.ReadLine();

            // Description
            Console.Write("Please enter a Description: ");
            tempMenuItem.Description = Console.ReadLine();
            
            // Ingredients
            Console.Write("Please enter the list of Ingredients: ");
            tempMenuItem.Ingredients = Console.ReadLine();

            // Price
            Console.Write("Please enter the Total Price of the Item: ");
            tempMenuItem.Price = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("");

            if (_menuRepo.AddItemToMenuList(tempMenuItem))
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
