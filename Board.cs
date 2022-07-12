using System;
using MasterMind_Project_2.console_display_classes;

namespace MasterMind_Project_2
{
    public class Board
    {
        //Class specific static variables.

        internal static int Row;
        internal static int Columns;
        internal static bool IsSessionValid;

        //class specific not static varriables

		private int _guessCounter;
        internal int GuessCounter { get => _guessCounter; set { _guessCounter = value; }}
        private bool _isGuessValid;
        internal bool IsGuessValid { get => _isGuessValid; set => _isGuessValid = value; }
		internal bool IsWin { get; set; }
		internal bool IsGameOver { get; set; }


        //Object inicialisations for setting defult values

        private static Solution _solution;
        private static Guess _guess;
        private static Hint _hint;
        internal static Solution Solution { get => _solution; }
        internal static Guess Guess { get => _guess; set => _guess = value; }
        internal static Hint Hint { get => _hint; set => _hint = value; }

		// Display variables:
		internal ConsoleMenu Menu { get; set; } 

		static Board()
		{
			Row = 10;
            Columns = 4;
            _solution = new Solution();
			_guess = new Guess();
			_hint = new Hint();
		}

        public Board ( )
        {
			Menu = new ConsoleMenu();
			Menu.DisplayMenu();
            GuessCounter = 0;
            IsSessionValid = true;
        }
        public Board ( int row, int columns, bool isSessionValid )
        {
            Row = row;
            Columns = columns;
            GuessCounter = 0;
            _solution = new Solution();
			_guess = new Guess();
			_hint = new Hint();
            IsSessionValid = isSessionValid;
        }
                                
        internal bool GameOver ()
        {
            if ( GuessCounter >= Row || Win() )
			{
				IsGameOver = true;
				DisplayOnConsole.GameOverDisplay(IsWin, Solution);
				Menu.DisplayMenu();
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