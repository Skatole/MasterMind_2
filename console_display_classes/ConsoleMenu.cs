using Pastel;
using MasterMind_Project_2.Interfaces.Menu;

namespace MasterMind_Project_2.console_display_classes
{
    public static class ConsoleMenu
    {
        public static void DisplayMenuOptions()
        {
            System.Console.WriteLine(" \n  \n Press: [ 1 ] to Start. \n".Pastel(System.Drawing.Color.LimeGreen));
            System.Console.WriteLine(" \n Press: [ 2 ] for Settings. \n ".Pastel(System.Drawing.Color.RoyalBlue));
            System.Console.WriteLine(" \n Press: [ 3 ] for Autosolve. \n ".Pastel(System.Drawing.Color.ForestGreen));
            System.Console.WriteLine(" \n Press: [ 4 ] for Info Page. \n ".Pastel(System.Drawing.Color.RebeccaPurple));
            System.Console.WriteLine(" \n Press: [ 5 ] to Exit. \n ".Pastel(System.Drawing.Color.DarkRed));
        }
    }
}