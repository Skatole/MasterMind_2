using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public class ConsoleMenu : Board
    {
        
        // Settings
        // Choose Display type Console vs. Form
        // Calls Board and Appropriate Display Class

        private const string Route = "Welcome.txt";


        internal void DisplayMenu()
        {
            string input = MenuOptions();
            while( IsSessionValid )
            {
                Navigate(input);
            }
        }

        private string MenuOptions()
        {
            System.Console.WriteLine(" Press: [ 1 ] to Start.".Pastel(System.Drawing.Color.LimeGreen));
            System.Console.WriteLine(" Press: [ 2 ] for Settings.".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" Press: [ 3 ] for Autosolve.".Pastel(System.Drawing.Color.ForestGreen));
            System.Console.WriteLine(" Press: [ 4 ] for Info Page.".Pastel(System.Drawing.Color.RebeccaPurple));
            System.Console.WriteLine(" Press: [ 5 ] to Exit.".Pastel(System.Drawing.Color.DarkRed));
            string input = Console.ReadLine();
            return input;
        }

        private void Navigate(string input)
        {
            foreach (var item in input)
            {
                switch(item)
                {
                    case '1': { 
        				DisplayOnConsole.DisplayBoard(Guess.Guess, Hint.Hint);
                        StartGame(); break; }
                    case '2': { 

                        // Settings();

                        System.Console.WriteLine("Not yet implemented. Sry :(");
                        DisplayMenu();
                        continue;}
                    case '3': {

                        // Autosolve();
                        
                        System.Console.WriteLine("Not yet implemented. Sry :(");
                        DisplayMenu();
                        continue;
                    }
                    case '4':
                    {
                        DisplayOnConsole.Welcome(Route);
                        DisplayMenu();
                        break;
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