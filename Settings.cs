using Pastel;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    public static class Settings
    {
        
        public static (int, int) ChooseSetting()
        {
            System.Console.WriteLine("Choose a setting and press ENTER: ");
            return OpenSettingSubMenu(ShowSettings());

        }

        private static string ShowSettings()
        {
            System.Console.WriteLine(" \n For setting custom Row & Column values press: [ 1 ] \n".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n For alloweing Empty pins press: [ 2 ]".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n To Go back to the Main menu press: [ 3 ]".Pastel(System.Drawing.Color.DarkRed));

            string input = Console.ReadLine();

            return input;
        }

        private static (int,int) OpenSettingSubMenu(string input)
        {
            int Row = 0;
            int Column = 0;
            if (input.Length == 1)
            {
                foreach (var character in input)
                {
                    switch(character)
                    {
                        case '1':
                        {
                            
                            
                            System.Console.WriteLine(" \n Give me the new Row value. ( Note: Represents how many tries you want.) : \n".Pastel(System.Drawing.Color.BlueViolet));
                            int.TryParse(Console.ReadLine(), out Row);
                            System.Console.WriteLine( " \n Give me the new Column value. (Note: represents how long a Guess and a Solution needs to be.): \n ".Pastel(System.Drawing.Color.BlueViolet));
                            int.TryParse(Console.ReadLine(), out Column);

                            // Board customBoard = new Board(Row, Column);
                            break;
                        }
                        case '3':
                        {
                            ConsoleMenu.DisplayMenu();
                            break;
                        }
                        default:
                        {
                            System.Console.WriteLine(" \n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
                            ChooseSetting();
                            continue;
                        }
                    }

                }
            }
            else
            {
                System.Console.WriteLine("\n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
            }

            return (Row, Column);
        }
    }
}