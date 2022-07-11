

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

        internal static void Welcome ( string route )
        {

            FileInfo fi = new FileInfo(route);
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

        internal static void DisplayBoard ( Guess guess, Hint hint)
        {
            guess = PinShapeDefiner.defineShape(Guess.Guess);
            hint = PinShapeDefiner.defineShape(Hint.Hint);
            //Display Hint
            Console.WriteLine(
                "\n	Color Input Options:"
                + "	B".Pastel(Color.Blue)
                + "	C".Pastel(Color.Cyan)
                + "	B".Pastel(Color.Black)
                + "	G".Pastel(Color.Green)
                + "	Y".Pastel(Color.Yellow)
                + "	W".Pastel(Color.WhiteSmoke)
                + "	P".Pastel(Color.BlueViolet)
                + "\n");

            for ( int i = 0; i < Board.Row; i++ )
            {

                foreach ( var pin in Guess.Guess.GuessBoard [ i ] )
                {
                    System.Console.Write($" | {pin.shape} | ");
                }
                Console.Write("  ==>  ");

                foreach ( var pin in Hint.Hint.HintBoard [i] )
                {
                    System.Console.Write($" ( {pin.shape} )");
                }
                System.Console.Write("\n");
            }
        }
    }

}
