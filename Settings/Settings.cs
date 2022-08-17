using Pastel;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2.Settings
{
    public class Settings : ISettings
    {
        private bool Return { get; set; }
        public IConfig Config { get; set; }
        public int _rows;
        public int _columns;
        public bool _isNoneAllowed;

        public Settings(IConfig config)
        {
            Return = false;
            Config = config; 
            _rows = config.Rows;
            _columns = config.Columns;
            _isNoneAllowed = config.IsNoneAllowed;

        }
        public IConfig OpenSettingSubMenu()
        {

           if (!Return)
           {
               CustomConfig(DisplaySettingsOnConsole.ShowSettings());
           }

            Return = false;
           return Config;
        }
        public void CustomConfig(string input)
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
                            int.TryParse(Console.ReadLine(), out _rows);
                            Config.Rows = _rows;
                            System.Console.WriteLine( " \n Give me the new Column value. (Note: represents how long a Guess and a Solution needs to be.): \n ".Pastel(System.Drawing.Color.BlueViolet));
                            int.TryParse(Console.ReadLine(), out _columns);
                            Config.Columns = _columns;
                            break;
                        }
                        case '2':
                        {
                            _isNoneAllowed = !_isNoneAllowed;
                            string output = _isNoneAllowed ? "\n Empty Pins enabled.".Pastel(System.Drawing.Color.OrangeRed) : " \n Empty Pins disabled.".Pastel(System.Drawing.Color.OrangeRed);
                            System.Console.WriteLine(output); 
                            Config.IsNoneAllowed = _isNoneAllowed;
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

            OpenSettingSubMenu();
        }
    }
}