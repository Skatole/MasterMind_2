using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public class ConsoleMenu
    {
        
        // Settings
        // Choose Display type Console vs. Form
        // Calls Board and Appropriate Display Class

        private const string Route = "Welcome.txt";


        internal void DisplayMenu(Board board)
        {
            DisplayOnConsole.Welcome(Route);
            string input = MenuOptions();
            Navigate(input, board);
        }

        private string MenuOptions()
        {
            System.Console.WriteLine(" Press: [ 1 ] to Start.".Pastel(System.Drawing.Color.RebeccaPurple));
            System.Console.WriteLine(" Press: [ 2 ] for Settings.".Pastel(System.Drawing.Color.ForestGreen));
            System.Console.WriteLine(" Press: [ 3 ] to Exit.".Pastel(System.Drawing.Color.DarkRed));
            string input = Console.ReadLine();
            return input;
        }

        private void Navigate(string input, Board board)
        {
            foreach (var item in input)
            {
                switch(item)
                {
                    case '1': { board.Start(); break; }
                    // case '2': { Settings(); break;}
                    case '3': 
                    {
                        System.Console.WriteLine("Good By".Pastel(System.Drawing.Color.Coral));
                        board.IsGuessValid = false;
                        break;
                    }
                    default :
                    {
                        System.Console.WriteLine("Invalid input, please try again!");
                        break;
                    }

                }
            }
        }




        
    }
}