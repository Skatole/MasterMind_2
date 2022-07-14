using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public static class ConsoleMenu
    {
        
        // Settings
        // Choose Display type Console vs. Form
        // Calls Board and Appropriate Display Class
        internal static bool IsSessionValid = true;


        internal static void DisplayMenu()
        {
            while( IsSessionValid )
            {
                DisplayOnConsole.Welcome();
                Navigate(MenuOptions());
            }
        }

        private static string MenuOptions()
        {
            string input = string.Empty;

            System.Console.WriteLine(" \n  \n Press: [ 1 ] to Start. \n".Pastel(System.Drawing.Color.LimeGreen));
            System.Console.WriteLine(" \n Press: [ 2 ] for Settings. \n ".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n Press: [ 3 ] for Autosolve. \n ".Pastel(System.Drawing.Color.ForestGreen));
            System.Console.WriteLine(" \n Press: [ 4 ] for Info Page. \n ".Pastel(System.Drawing.Color.RebeccaPurple));
            System.Console.WriteLine(" \n Press: [ 5 ] to Exit. \n ".Pastel(System.Drawing.Color.DarkRed));
            input = Console.ReadLine();
            

             return input;

        }

        private static void Navigate(string input)
        {

            foreach (var item in input)
            {
                switch(item)
                {
                    case '1': 
                    {
                        Board defaultBoard = Sequencer.DefaultStartingSequence();
        				DisplayOnConsole.DisplayBoard(defaultBoard.Guess, defaultBoard.Hint, defaultBoard.Row);
                        defaultBoard.StartGame();
                        break; 
                    }
                    case '2': 
                    { 

                        // Settings();

                        System.Console.WriteLine("Not yet implemented. Sry :(");
                        DisplayMenu();
                        continue;
                    }
                    case '3':
                    {

                        // Autosolve();
                        
                        System.Console.WriteLine("Not yet implemented. Sry :(");
                        DisplayMenu();
                        continue;
                    }
                    case '4':
                    {
                        DisplayOnConsole.Info();
                        DisplayMenu();
                        continue;
                    }
                    case '5': 
                    {
                        System.Console.WriteLine("Good By".Pastel(System.Drawing.Color.Coral));
                        IsSessionValid = false;
                        break;
                    }
                    default :
                    {
                        System.Console.WriteLine("Invalid input, please try again!".Pastel(System.Drawing.Color.DarkRed));
                        continue;
                    }

                }
            }
        }




        
    }
}