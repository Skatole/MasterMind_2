

using System;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    class Program
    {
        private const string Route = "Welcome.txt";

        private static void Main(String[] args)
        {

            Board Board = new Board();
            
            ConsoleMenu Menu = new ConsoleMenu();
            DisplayOnConsole ConsoleDisplay = new DisplayOnConsole();
            ConsoleDisplay.ParseText(Route);

            while (Board.SessionValidator())
            { 
                ConsoleDisplay.DisplayBoard();
                Board.GuessString = ConsoleDisplay.AskForGuess();


               






                // var days =  Enum.GetValues(typeof(PinColor))
                //         .Cast<PinColor>()
                //         .Select(d => (d, (char)d))
                //         .ToList();

                // Console.WriteLine(String.Join(Environment.NewLine, days));




                Board.IsSessionValid = false;
            }


        }
    }

}
