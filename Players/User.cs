using Pastel;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Settings;

namespace MasterMind_Project_2.Players
{
    public class User : IUser
    {
        public int Points { get; set; }
        public int Rounds { get; set; }
        public string Name { get; set; }

        public User( IConfig config )
        {
            Points = 0;
            Rounds = 
        }
        public string GiveInput()
        {
            string? input = Console.ReadLine();
            return input;
        }
        public void DecideRole()
        {
            Console.WriteLine(" Press 1 if you want to start as Player/Guesser. \n Press 2 if you want to start as Master".Pastel(System.Drawing.Color.DarkRed));
        }
        public IConfig SetSettings(ISettings settings)
        {
            settings.OpenSettingSubMenu();
            return settings.Config;
        }

        public string Login()
        {
            System.Console.WriteLine("ENTER YOUR NAME: \n");
            string input = Console.ReadLine();
            return input;
            // Its gona be empty for now ==> When DB or mock DB is set then implement.
        }

        public void Register() {}

        public IConfig Navigate(INavigator navigator, IMenu menu, ISettings settings, IConfig config )
        {

            return config;

        }


        
    }
}