using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    public static class DisplaySettingsOnConsole
    {
        public static  string ShowSettings()
        {
            System.Console.WriteLine(" \n For setting custom Row & Column values press: [ 1 ] \n".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n For allowing Empty pins press: [ 2 ]".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n To Go back to the Main menu press: [ 3 ]".Pastel(System.Drawing.Color.DarkRed));

            string input = Console.ReadLine();

            return input;
        }
    }
}