using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public static class ConsoleMenu
    {

        private static (int, int, bool) _settingsReturnTuple = (0,0, false);

        
        // Settings
        // Choose Display type Console vs. Form
        // Calls Board and Appropriate Display Class
        internal static bool IsSessionValid = true;


        internal static void DisplayMenu()
        {
            while( IsSessionValid )
            {
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
                        // Start:

                        if (_settingsReturnTuple.Item1 != 0 && _settingsReturnTuple.Item2 != 0 || _settingsReturnTuple.Item3)
                        {
                            System.Console.WriteLine(" Would you like to start with Custom settings? Y/N".Pastel(System.Drawing.Color.ForestGreen));
                            string input2 = Console.ReadLine().ToUpper();
                            foreach (var i in input2)
                            {
                                switch(i)
                                {
                                    case ('Y'):
                                    {
                                        if (_settingsReturnTuple.Item1 == 0 || _settingsReturnTuple.Item2 == 0)
                                        {
                                            Board withNoneBoard = Sequencer.StartingSequence(_settingsReturnTuple.Item3);
                                            DisplayOnConsole.DisplayBoard(withNoneBoard.Guess, withNoneBoard.Hint);
                                            withNoneBoard.StartGame();
                                        } else
                                        {
                                          Board customBoard = Sequencer.StartingSequence(_settingsReturnTuple);
                                          DisplayOnConsole.DisplayBoard(customBoard.Guess, customBoard.Hint);
                                          customBoard.StartGame();
                                        }
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
                        DisplayMenu();
                        break; 
                    }
                    case '2': 
                    { 
                        // Settings: 

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
                        //  Info

                        DisplayOnConsole.Info();
                        System.Console.WriteLine(" \n Press ENTER to go back! \n ".Pastel(System.Drawing.Color.ForestGreen));
                        string input3 = System.Console.ReadLine();
                        if (input3 != string.Empty )
                        {
                            DisplayMenu();
                        }
                        break;
                    }
                    case '5': 
                    {
                        System.Console.WriteLine(" \n Good By \n ".Pastel(System.Drawing.Color.Coral));
                        IsSessionValid = false;
                        break;
                    }
                    // case '6':
                    // {
                    //     System.Console.WriteLine("All possible combinations: ");
                    //     Sequencer.StartingSequence();
                    //     Permutations combin = new Permutations();
                    //     combin.StandardPermutation();
                    //     System.Console.WriteLine("permutation count: " + combin.permutationCount);
                    //     break;
                    // }
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