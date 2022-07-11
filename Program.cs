

using System;

using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main ( String [ ] args )
        {

            Board Board = new Board();

            ConsoleMenu Menu = new ConsoleMenu();
            Menu.DisplayMenu(Board);



            // while ( Board.SessionValidator() )
            // {

            //     Board.Guess.CleanAndValidate(ConsoleDisplay.AskForGuess(), );
            //     ConsoleDisplay.DisplayBoard(Board.Guess, Board.Hint);
            // }
        }
    }

}
