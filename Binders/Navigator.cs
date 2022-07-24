using Pastel;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2.Binders
{
    public class Navigator : INavigator
    {
        public bool IsCustomGame { get; set; }
        public IConfig? CustomConfig { get; set; }


        public IConfig Navigate( IMenu menu, ISettings settings, IConfig config )
        {
            string input = menu.DisplayMenuOptions();
            foreach (var item in input)
            {
                switch(item)
                {
                    case '1': 
                    {
                        // Start:

                        if (CustomConfig != null)
                        {
                            System.Console.WriteLine(" Would you like to start with Custom settings? Y/N".Pastel(System.Drawing.Color.ForestGreen));
                            string? input2 = Console.ReadLine().ToUpper();
                            foreach (var i in input2)
                            {
                                switch(i)
                                {
                                    case ('Y'):
                                    {
                                        IsCustomGame = true;
                                        return CustomConfig;
                                    }
                                    case 'N':
                                    {
                                        IsCustomGame = false;
                                        return config;
                                    }
                                }
                            }
                        } else
                        {
                            return config;
                        }
                        break; 
                    }
                    case '2': 
                    { 
                        // Settings: 
                        settings.OpenSettingSubMenu();
                        CustomConfig = settings.Config;
                        Navigate(menu, settings, config);
                        continue;
                    }
                    case '3':
                    {

                        // Autosolve();
                        
                        System.Console.WriteLine("Not yet implemented. Sry :(");
                        Navigate(menu, settings, config);
                        continue;
                    }
                    case '4':
                    {
                        //  Info

                        DisplayOnConsole.Info();
                        System.Console.WriteLine(" \n Press ENTER to go back! \n ".Pastel(System.Drawing.Color.ForestGreen));
                        string? input3 = System.Console.ReadLine();
                        if (input3 != string.Empty )
                        {
                            Navigate(menu, settings, config);
                        }
                        break;
                    }
                    case '5': 
                    {
                        System.Console.WriteLine(" \n Good By \n ".Pastel(System.Drawing.Color.Coral));
                        config.IsSessionValid = false;
                        return config;
                    }
                    default :
                    {
                        System.Console.WriteLine("Invalid input, please try again!".Pastel(System.Drawing.Color.DarkRed));
                        Navigate(menu, settings, config);
                        break;
                    }

                }
            }

            return config;
        }
    }
}