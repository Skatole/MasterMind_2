

// Az első futásnál kiírja a Txt fájlban leírt utasításokat
// Bekéri a Guesst a Program.cs helyett
// A guess bekérés után kirajzolja a Board által generált Guess és Hint Dictionariket
// A displayOnConsole class függvényét hívja meg az InputCleaner interface ha ? jelet talál.
using System.Drawing;

using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;

using Pastel;

namespace MasterMind_Project_2.console_display_classes
{
    internal static class DisplayOnConsole
    {

        private const string welcomeRoute = "TxtPages/Welcome.txt";
        private const string infoRoute = "TxtPages/InfoPage.txt";

        internal static void Welcome()
        {

            FileInfo fi = new FileInfo(welcomeRoute);
            StreamReader parser = fi.OpenText();
            string line;

            while ((line = parser.ReadLine()) != null)
            {
                string[] items = line.Split('\n');
                string path = null;
                foreach (string item in items)
                {
                    path = item;
                }
                Console.WriteLine(path);
            }
        }

        internal static void DecideRole()
        {
            Console.WriteLine(" \n (1) Start as Player < == > (2) Start as Master \n ".Pastel(Color.DarkGreen));
        }

        internal static void Info()
        {

            FileInfo fi = new FileInfo(infoRoute);
            StreamReader parser = fi.OpenText();
            string line;

            while ((line = parser.ReadLine()) != null)
            {
                string[] items = line.Split('\n');
                string path = null;
                foreach (string item in items)
                {
                    path = item;
                }
                Console.WriteLine(path);
            }
        }
        internal static void MakeAGuess()
        {
            Console.WriteLine("Make a Guess:");
        }

        internal static void DisplayBoard(IGuess guess, IHint hint)
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

            for (int i = 0; i < guess.Board.Count; i++)
            {

                foreach (var pin in guess.Board[i])
                {
                    System.Console.Write($" | {pin.Shape} | ");
                }
                Console.Write("  ==>  ");

                foreach (var pin in hint.Board[i])
                {
                    System.Console.Write($" ( {pin.Shape} )");
                }
                System.Console.Write("\n");
            }
        }

        internal static void GameOverDisplay(bool IsWin, IMappable solution, IConfig config)
        {
            GuessPin[] Pins = new GuessPin[solution.Board[config.Rounds].Length];
            Pins = PinShapeDefiner.defineShape((IGuess) solution);
            if (IsWin)
            {
                System.Console.WriteLine(" \n CONGRATULATIONSSSS CHAMPION YOU WIN!!! \n");
                System.Console.WriteLine(" \n THE SOLUTION WAS INDEED: \n");
                foreach (var item in Pins)
                {
                    System.Console.Write($" | {item.shape} | ");
                }

            }
            else
            {
                System.Console.WriteLine(" \n SORRY DUM DUM YOU LOST. THE SOLUTION WAS:  \n ");
                foreach (var item in Pins)
                {
                    System.Console.Write($" | {item.shape} | ");
                }

                System.Console.WriteLine("\n");
            }
        }
    }

}
