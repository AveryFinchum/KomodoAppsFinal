using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace KomodoBadgeSystem
{
    internal class KomodoBadgeSystemUI
    {
        private readonly KomodoBadgeSystemBadgeRepo _badgeRepo = new KomodoBadgeSystemBadgeRepo();

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
                Console.WriteLine(@"
Hello Security Admin, What would you like to do?

1) Add a badge
2) Edit a badge.
3) List all Badges.
4) Exit Application.");


                string userInput = Console.ReadLine().ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "1":
                    case "a":
                        AddBadge();
                        break;
                    case "2":
                    case "e":
                        EditBadge();
                        break;
                    case "3":
                    case "l":
                        DisplayAllBadges();
                        break;
                    case "4":
                    case "exit":
                    case "q":
                        mainMenu = false;
                        break;

                }
            }
        }


        //*************************************MENU METHODS**************************************

        //List all badges in order
        private void DisplayAllBadges()
        {//list all badges in system
            Console.Write("Badge #        Door Access");//write a nice header
            List<KomodoBadgeSystemBadge> _localbadges = _badgeRepo.GetAllBadges(); //Get all Badges gets them in order
            foreach (KomodoBadgeSystemBadge badge in _localbadges)//print each badge in badge repo
            {
                DisplayBadge(badge);//So this lists them in order
            }
            Console.WriteLine();
        }

        //Add a badge
        private void AddBadge()
        {
            //get all items in menu repo
            List<KomodoBadgeSystemBadge> badges = _badgeRepo.GetAllBadges();
            if (badges.Count != 0)
            {
                foreach (KomodoBadgeSystemBadge badge in badges)
                {
                    _badgeRepo.AddBadgeToBadgeRepo(badge);
                }
            }
            else
            {
                Console.WriteLine("There are no meals to list");
            }
            AnyKey();
        }
        //List all of one badge number(ideally this will list only one)
        private void ListBadge()
        {
            Console.Write("Enter a Badge number: ");
            // Capture number
            int number = int.Parse(Console.ReadLine());
            // Look up content
            List<KomodoBadgeSystemBadge> badges = _badgeRepo.GetBadgeByNumber(number);
            if (badges.Count != 0)
            {
                foreach (KomodoBadgeSystemBadge badge in badges)
                {
                    DisplayBadge(badge);
                }
            }
            else
            {
                Console.WriteLine("Couldn't find a Badge by that number");
            }
            AnyKey();
        }
        //Add
        private void EditBadge()
        {
            //Console.Clear(); 
            KomodoBadgeSystemBadge tempBadge = new KomodoBadgeSystemBadge();

            // badge Number
            Console.Write("Enter a new badge number if desired: ");
            tempBadge.BadgeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Would you like to 1) `R`emove or 2) `D`elete a door?");
            string userInput = Console.ReadLine().ToLower();
            Console.Clear();
            switch (userInput)
            {
                case "1":
                case "r":
                    //AddDoor(tempBadge);
                    break;
                case "2":
                case "d":
                    //RemoveDoor(tempBadge);
                    break;
            }



            // Name
            Console.Write("Please enter a door: ");
            tempBadge.BadgeNumber = int.Parse(Console.ReadLine());



            if (_badgeRepo.AddBadgeToBadgeRepo(tempBadge))
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
        private void DeleteBadge()
        {
            Console.Clear();

            List<KomodoBadgeSystemBadge> BadgeList = _badgeRepo.GetAllBadges();
            int count = 1;
            foreach (KomodoBadgeSystemBadge item in BadgeList)
            {
                Console.WriteLine($"{count}. {item.BadgeNumber}");
                count++;
            }
            Console.Write("What content do you want to remove: ");
            int itemMenuID = int.Parse(Console.ReadLine());
            int menuItemIndex = itemMenuID - 1;
            if (menuItemIndex >= 0 && menuItemIndex < BadgeList.Count())
            {
                KomodoBadgeSystemBadge intendedBadgeDeletion = BadgeList[menuItemIndex];
                if (_badgeRepo.DeleteExistingMenuItem(intendedBadgeDeletion))
                {
                    Console.WriteLine($"{intendedBadgeDeletion.BadgeNumber} deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                }
            }
            else
            {
                Console.WriteLine("No Badge has that Number");
            }
            AnyKey();
        }

        //************************************HELPER METHODS*************************************
        private void DisplayBadge(KomodoBadgeSystemBadge badge)
        {
            Console.Write(badge.BadgeNumber);                 //Write badge number
            Console.SetCursorPosition(15, Console.CursorTop); //Move console cursor over to the 16th colum
            Console.Write(badge.Doors);                       //List all doors
            Console.WriteLine("");                            //finish out this line
            Console.WriteLine("");                            //start next text on next line
        }

        private void WriteDoorsThatBelongToBadge(KomodoBadgeSystemBadge badge)// dont need this... ;.;
        {
            Console.Write(badge.Doors);
        }


        private void ConsoleWelcomeScreen()
        {
            string welcomeScreen = @"
   ██╗  ██╗ ██████╗ ███╗   ███╗ ██████╗ ██████╗  ██████╗    
   ██║ ██╔╝██╔═══██╗████╗ ████║██╔═══██╗██╔══██╗██╔═══██╗   
   █████╔╝ ██║   ██║██╔████╔██║██║   ██║██║  ██║██║   ██║   
   ██╔═██╗ ██║   ██║██║╚██╔╝██║██║   ██║██║  ██║██║   ██║   
   ██║  ██╗╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██████╔╝╚██████╔╝   
   ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝    

███████╗███████╗ ██████╗██╗   ██╗██████╗ ██╗████████╗██╗   ██╗
██╔════╝██╔════╝██╔════╝██║   ██║██╔══██╗██║╚══██╔══╝╚██╗ ██╔╝
███████╗█████╗  ██║     ██║   ██║██████╔╝██║   ██║    ╚████╔╝ 
╚════██║██╔══╝  ██║     ██║   ██║██╔══██╗██║   ██║     ╚██╔╝  
███████║███████╗╚██████╗╚██████╔╝██║  ██║██║   ██║      ██║   
╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝      ╚═╝   
                                                              
                                                                                                                                                 
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

