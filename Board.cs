using System;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    public class Board
    {

        //class specific not static varriables
        internal  int Row { get; set; }
        internal  int Columns { get; set; }
		private int _guessCounter;
        internal int GuessCounter { get => _guessCounter; set { _guessCounter = value; }}
        private bool _isGuessValid;
        internal bool IsGuessValid { get => _isGuessValid; set => _isGuessValid = value; }
		internal bool IsWin { get; set; }
		internal bool IsGameOver { get; set; }


        //Object inicialisations for setting defult values

        private  Solution _solution;
        private  Guess _guess;
        private  Hint _hint;
        internal  Solution Solution { get => _solution; set => _solution = value; }
        internal  Guess Guess { get => _guess; set => _guess = value; }
        internal  Hint Hint { get => _hint; set => _hint = value; }

		public Board()
		{
			GuessCounter = 0;
			Row = 10;
			Columns = 4;

		}
        public Board ( int row, int columns ) 
        {
            GuessCounter = 0;
            Row = row;
            Columns = columns;
			System.Console.WriteLine("Board: " + " GUessCount: " + GuessCounter + " ROW: " + Row + " Columns:  " + Columns );
        }
                                
        internal bool GameOver ()
        {
            if ( GuessCounter >= Row || Win() )
			{
				IsGameOver = true;
				DisplayOnConsole.GameOverDisplay(IsWin, Solution);
				ConsoleMenu.DisplayMenu();
			}
			else
			{
				IsGameOver = false;
			}

			return IsGameOver;
        }

		internal void StartGame()
		{
			while(!GameOver())
			{
				List<(GuessPin Pin, bool Valid)> convGuess = Guess.PinConverter( 
					Guess.CleanAndValidate(
						DisplayOnConsole.AskForGuess(),
						Columns,
						Row,
						out _isGuessValid),
					ref _isGuessValid);

				if ( IsGuessValid )
				{
					Guess.mapper(convGuess, Guess.GuessBoard, ref _guessCounter, ref _isGuessValid);
					Hint.GenerateHint(Guess, Solution, ref _guessCounter);
					DisplayOnConsole.DisplayBoard(Guess, Hint);
					Win();
					GuessCounter++;
				}

			}
		}

		internal bool Win()
		{

			if ( Hint.InPlace == Columns )
			{
				IsWin = true;
			}
			else
			{
				IsWin = false;
			}
			return IsWin;
		}

    }
}