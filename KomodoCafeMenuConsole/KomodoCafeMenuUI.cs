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
        private readonly KomodoCafeMenuRepo _menuRepo = new KomodoCafeMenuRepo();

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
                    "3. View a meal by number \n" +
                    "4. Delete an existing meal\n" +
                    "5. Exit Application");


                string userInput = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                    case "l":
                    case "v":
                        ListAllMeals();
                        break;
                    case "2":
                    case "a":
                        AddMeal();
                        break;
                    case "3":
                    case "d":
                        GetMealBynumber();
                        break;
                    case "4":
                    case "m":
                        DeleteMeal();
                        break;
                    case "5":
                    case "exit":
                    case "e":
                        mainMenu = false;
                        break;

                }
            }
        }


        //*************************************MENU METHODS**************************************
        //List all in order
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

        //Add
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
        // Delete
        private void DeleteMeal()
        {
            Console.Clear();

            List<MenuItem> contentList = _menuRepo.GetMenuItems();
            int count = 1;
            foreach (MenuItem item in contentList)
            {
                Console.WriteLine($"{count}. {item.Number}");
                count++;
            }
            Console.Write("What content do you want to remove: ");
            int itemMenuID = int.Parse(Console.ReadLine());
            int menuItemIndex = itemMenuID - 1;
            if (menuItemIndex >= 0 && menuItemIndex < contentList.Count())
            {
                MenuItem intendedMenuDeletion = contentList[menuItemIndex];
                if (_menuRepo.DeleteExistingMenuItem(intendedMenuDeletion))
                {
                    Console.WriteLine($"{intendedMenuDeletion.Number} deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            else
            {
                Console.WriteLine("No Meal has that Number");
            }
            AnyKey();
        }

        //************************************HELPER METHODS*************************************
        private void DisplayContent(MenuItem item)
        {
            Console.WriteLine("" +
               $"Meal Number: {item.Number}\n" +
               $"Name:        {item.Name}\n" +
               $"Description: {item.Description}\n" +
               $"Ingredients: {item.Ingredients}\n" +
               $"Price:       {item.Price}\n");
        }
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
