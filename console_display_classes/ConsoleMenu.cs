using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public static class ConsoleMenu
    {

        private static (int, int) _settingsReturnTuple = (0,0);

        
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
                        if (_settingsReturnTuple.Item1 != 0 && _settingsReturnTuple.Item2 != 0)
                        {
                            System.Console.WriteLine(" Would you like to start with Custom settings? Y/N".Pastel(System.Drawing.Color.ForestGreen));
                            string input2 = Console.ReadLine().ToUpper();
                            foreach (var i in input2)
                            {
                                switch(i)
                                {
                                    case ('Y'):
                                    {

                                        System.Console.WriteLine("CICA");
                                        Board customBoard = Sequencer.StartingSequence(_settingsReturnTuple);
                                        DisplayOnConsole.DisplayBoard(customBoard.Guess, customBoard.Hint);
                                        customBoard.StartGame();
                                        break;
                                    }
                                    case 'N':
                                    {
                                        Board defaultBoard = Sequencer.StartingSequence();
        				                DisplayOnConsole.DisplayBoard(defaultBoard.Guess, defaultBoard.Hint);
                                        defaultBoard.StartGame();
                                        break; 
                                    }
                                }
                            }
                        } else
                        {
                        Board Board = Sequencer.StartingSequence();
        				DisplayOnConsole.DisplayBoard(Board.Guess, Board.Hint);
                        Board.StartGame();
                        }
                        break; 
                    }
                    case '2': 
                    { 
                        _settingsReturnTuple = Settings.ChooseSetting();
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
                    case '6':
                    {
                        System.Console.WriteLine("All possible combinations: ");
                        Sequencer.StartingSequence();
                        AllPossibleCombinations combin = new AllPossibleCombinations();
                        combin.Standard();
                        System.Console.WriteLine("permutation count: " + combin.permutationCount);
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