using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Menu;

using Pastel;

namespace MasterMind_Project_2.Configuration.ConsoleSettings
{
    public class Settings : ISettings
    {
        private IUser _user;
        private bool _return = false;
        public int _rows;
        public int _columns;
        public bool _isNoneAllowed;

        public Settings(IUser user)
        {
            _user = user;
        }

        public IConfig OpenSettingSubMenu()
        {

            if (!_return)
            {
                DisplaySettingsOnConsole.ShowSettings();
                string input = _user.GiveInput();
                CustomConfig(input);
            }

            return _user.userConfig;
        }
        public void CustomConfig(string input)
        {

            if (input.Length == 1)
            {
                foreach (var character in input)
                {
                    switch (character)
                    {
                        case '1':
                            {
                                Console.WriteLine(" \n Give me the new Row value. ( Note: Represents how many TRIES you want.) : \n".Pastel(System.Drawing.Color.BlueViolet));
                                int.TryParse(Console.ReadLine(), out _rows);
                                _user.userConfig.Rows = _rows;
                                Console.WriteLine(" \n Give me the new Column value. (Note: Represents how LONG a Guess and a Solution needs to be.): \n ".Pastel(System.Drawing.Color.BlueViolet));
                                int.TryParse(Console.ReadLine(), out _columns);
                                _user.userConfig.Columns = _columns;
                                break;
                            }
                        case '2':
                            {
                                _isNoneAllowed = !_isNoneAllowed;
                                string output = _isNoneAllowed ? "\n Empty Pins enabled.".Pastel(System.Drawing.Color.OrangeRed) : " \n Empty Pins disabled.".Pastel(System.Drawing.Color.OrangeRed);
                                Console.WriteLine(output);
                                _user.userConfig.IsNoneAllowed = _isNoneAllowed;
                                break;
                            }
                        case '3':
                            {
                                _return = !_return;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(" \n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
                                continue;
                            }
                    }

                }
            }
            else
            {
                Console.WriteLine("\n Invalid input. \n Please choose from the given input options. \n".Pastel(System.Drawing.Color.Red));
            }

            OpenSettingSubMenu();
        }
    }
}