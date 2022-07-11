

using System;

using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    class Program
    {
        private const string Route = "Welcome.txt";

        private static void Main ( String [ ] args )
        {

            Board Board = new Board();

            ConsoleMenu Menu = new ConsoleMenu();
            DisplayOnConsole ConsoleDisplay = new DisplayOnConsole();
            ConsoleDisplay.ParseText(Route);
            ConsoleDisplay.DisplayBoard();


            while ( Board.SessionValidator() )
            {
                Board.GuessString = ConsoleDisplay.AskForGuess();
                ConsoleDisplay.DisplayBoard();
            }
        }
    }

}
