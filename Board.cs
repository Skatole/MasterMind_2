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

        //Object inicialisations for setting defult values

        private static Solution _solution;
        private static Guess _guess;
        private static Hint _hint;
        internal static Solution Solution { get => _solution; }
        internal static Guess Guess { get => _guess; set => _guess = value; }
        internal static Hint Hint { get => _hint; set => _hint = value; }

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
                                
        internal bool SessionValidator ( )
        {
            if ( GuessCounter >= Row)
			{
				IsSessionValid = false;
			} else
			{
				IsSessionValid = true;
			}

			return IsSessionValid;
        }

		internal void Start()
		{
			while(SessionValidator())
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
					Hint.GenerateHint2(Guess, Solution, ref _guessCounter);
					DisplayOnConsole.DisplayBoard(Guess, Hint);
					GuessCounter++;
				}

			}
		}

    }
}