

// Az első futásnál kiírja a Txt fájlban leírt utasításokat
// Bekéri a Guesst a Program.cs helyett
// A guess bekérés után kirajzolja a Board által generált Guess és Hint Dictionariket
// A displayOnConsole class függvényét hívja meg az InputCleaner interface ha ? jelet talál.
using System;
using System.Drawing;

using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    internal static class DisplayOnConsole
    {

        private const string welcomeRoute = "Welcome.txt";
        private const string infoRoute = "InfoPage.txt";

        internal static void Welcome ()
        {

            FileInfo fi = new FileInfo(welcomeRoute);
            StreamReader parser = fi.OpenText();
            string line;

            while ( (line = parser.ReadLine()) != null )
            {
                string[] items = line.Split('\n');
                string path = null;
                foreach ( string item in items )
                {
                    path = item;
                }
                Console.WriteLine(path);
            }
        }

          internal static void Info ()
        {

            FileInfo fi = new FileInfo(infoRoute);
            StreamReader parser = fi.OpenText();
            string line;

            while ( (line = parser.ReadLine()) != null )
            {
                string[] items = line.Split('\n');
                string path = null;
                foreach ( string item in items )
                {
                    path = item;
                }
                Console.WriteLine(path);
            }
        }
        internal static string AskForGuess ( )
        {
            string guessString = new string(string.Empty);

            Console.WriteLine("Make a Guess:");
            guessString = Console.ReadLine();

            return guessString;
        }

        internal static void DisplayBoard ( Guess? guess, Hint? hint)
        {
            guess = PinShapeDefiner.defineShape(guess);
            hint = PinShapeDefiner.defineShape(hint);
            //Display Hint
            Console.WriteLine(
                "\n	Color Input Options:"
                + "	B".Pastel(Color.Blue)
                + "	C".Pastel(Color.Cyan)
                + "	X".Pastel(Color.Black)
                + "	G".Pastel(Color.Green)
                + "	Y".Pastel(Color.Yellow)
                + "	P".Pastel(Color.BlueViolet)
                + "\n");

            for ( int i = 0; i < guess.GuessBoard.Count; i++ )
            {

                foreach ( var pin in guess.GuessBoard [ i ] )
                {
                    System.Console.Write($" | {pin.shape} | ");
                }
                Console.Write("  ==>  ");

                foreach ( var pin in hint.HintBoard [i] )
                {
                    System.Console.Write($" ( {pin.shape} )");
                }
                System.Console.Write("\n");
            }
        }

        internal static void GameOverDisplay(bool IsWin, Solution solution)
        {
            GuessPin[] Pins = new GuessPin[solution.Sol.Length];

            for (int i = 0; i < solution.Sol.Length; i++)
            {
               Pins[i] = new GuessPin( solution.Sol[i] );
            }

            Pins = PinShapeDefiner.defineShape(Pins);
            if (IsWin)
            {
                System.Console.WriteLine(" \n CONGRATULATIONSSSS CHAMPION YOU WIN!!! \n ");
                System.Console.Write(" \n THE SOLUTION WAS INDEED: ");
                foreach (var item in Pins)
                {
                    System.Console.Write($" | {item.shape} | ");
                }

                Console.WriteLine("\n");

            }
            else
            {
                System.Console.WriteLine("SORRY DUM DUM YOU LOST. THE SOLUTION WAS: ");
                  foreach (var item in Pins)
                {
                    System.Console.Write($" | {item.shape} | ");
                }
            }
        }
    }

}
