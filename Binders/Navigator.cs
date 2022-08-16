using Pastel;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.Interfaces.Menu;

namespace MasterMind_Project_2.Binders
{
    public class Navigator : INavigator
    {


        public IConfig Navigate(IUser user, ISettings settings, IConfig config)
        {
            ConsoleMenu.DisplayMenuOptions();

            foreach (char item in user.GiveInput())
            {
                switch (item)
                {
                    case '1':
                        {
                            // Start:

                            if (user.userConfig != null)
                            {
                                System.Console.WriteLine(" Would you like to start with Custom settings? Y/N".Pastel(System.Drawing.Color.ForestGreen));
                                string? input2 = user.GiveInput().ToUpper();
                                foreach (var i in input2)
                                {
                                    switch (i)
                                    {
                                        case ('Y'):
                                            {
                                                return user.userConfig;
                                            }
                                        case 'N':
                                            {
                                                return config;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                return config;
                            }
                            break;
                        }
                    case '2':
                        {
                            // Settings: 
                            settings.OpenSettingSubMenu();
                            Navigate(user, settings, config);
                            break;
                        }
                    case '3':
                        {

                            // Autosolve();

                            System.Console.WriteLine("Not yet implemented. Sry :(");
                            Navigate(user, settings, config);
                            break;
                        }
                    case '4':
                        {
                            //  Info

                            DisplayOnConsole.Info();
                            System.Console.WriteLine(" \n Press ENTER to go back! \n ".Pastel(System.Drawing.Color.ForestGreen));

                            if (user.GiveInput() != string.Empty)
                            {
                                Navigate(user, settings, config);
                            }
                            break;
                        }
                    case '5':
                        {
                            System.Console.WriteLine(" \n Good By \n ".Pastel(System.Drawing.Color.Coral));
                            System.Environment.Exit(1);
                            return config;
                        }
                    default:
                        {
                            System.Console.WriteLine("Invalid input, please try again!".Pastel(System.Drawing.Color.DarkRed));
                            Navigate(user, settings, config);
                            break;
                        }

                }
            }

            return config;
        }
    }
}