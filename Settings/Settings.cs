using Pastel;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    public static class Settings
    {
        private static  bool isNoneAllowed = false;
        private static bool Return = false;
        private static int Row = 0;
        private static int Column = 0;
        
        public static (int, int, bool) ChooseSetting()
        {
            System.Console.WriteLine("Choose a setting and press ENTER: ");

           if (!Return)
           {
               ShowSettings();
           }

            Return = false;
           return (Row, Column, isNoneAllowed);
        }

        private static void ShowSettings()
        {
            System.Console.WriteLine(" \n For setting custom Row & Column values press: [ 1 ] \n".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n For allowing Empty pins press: [ 2 ]".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n To Go back to the Main menu press: [ 3 ]".Pastel(System.Drawing.Color.DarkRed));

            string input = Console.ReadLine();

            OpenSettingSubMenu(input);
        }

        private static void OpenSettingSubMenu(string input)
        {
            
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
                            break;
                        }
                        case '2':
                        {
                            isNoneAllowed = !isNoneAllowed;
                            string output = isNoneAllowed ? "\n Empty Pins enabled.".Pastel(System.Drawing.Color.OrangeRed) : " \n Empty Pins disabled.".Pastel(System.Drawing.Color.OrangeRed);
                            System.Console.WriteLine(output); 
                            break;
                        }
                        case '3':
                        {
                            Return = !Return;
                            break;
                        }
                        default:
                        {
                            System.Console.WriteLine(" \n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
                            continue;
                        }
                    }

                }
            }
            else
            {
                System.Console.WriteLine("\n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
            }

            System.Console.WriteLine("IN SETTINGS: " + " ROW : " + Row + " COLUMNS: " + Column + " NONEALLOWED: " + isNoneAllowed);
            ChooseSetting();
        }
    }
}