using System;
using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.Interfaces;

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
		internal bool IsNoneAllowed { get; set; }


        //Object inicialisations for setting defult values

        private  Solution _solution;
        private  Guess _guess;
        private  Hint _hint;
		internal Permutations Permutations { get; set; }
        internal  Solution Solution { get => _solution; set => _solution = value; }
        internal  Guess Guess { get => _guess; set => _guess = value; }
        internal  Hint Hint { get => _hint; set => _hint = value; }

		public Board()
		{
			GuessCounter = 0;
			Row = 10;
			Columns = 4;
			IsNoneAllowed = false;
		}

		public Board(bool isNoneAllowed)
		{
			GuessCounter = 0;
			Row = 10;
			Columns = 4;
			IsNoneAllowed = false;
		}
        public Board ( int row, int columns, bool isNoneAllowed ) 
        {
            GuessCounter = 0;
            Row = row;
            Columns = columns;
			IsNoneAllowed = isNoneAllowed;
        }

		public void StartGame ( )
		{
			while ( !GameOver() )
			{
				List<(GuessPin Pin, bool Valid)> convGuess = Guess.PinConverter(
					Guess.CleanAndValidate(
						DisplayOnConsole.MakeAGuess(),
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



		internal bool GameOver ()
        {
            if ( GuessCounter >= Row || Win() )
			{
				IsGameOver = true;
				DisplayOnConsole.GameOverDisplay(IsWin, Solution);
			}
			else
			{
				IsGameOver = false;
			}

			return IsGameOver;
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