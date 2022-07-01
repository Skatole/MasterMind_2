using System;

namespace MasterMind_Project_2
{
    public class Board
    {

        //Class specific static variables.
        internal static int Row;
        internal static int Columns;
        internal static bool IsSessionValid;
        internal static int GuessCounter;

        //class specific not static varriables

        private bool _isGuessValid;

        internal bool IsGuessValid { get => _isGuessValid; set => _isGuessValid = value; }
        private string _guessString;
        internal string GuessString { 
            get => _guessString;
            set
            {
                _guessString = value;
                IInputCleaner _guessValidator = Guess;
                IPinConverter _convertPin = Guess;
                var localPassableVar = _guessValidator.CleanAndValidate(_guessString, Columns, Row, out _isGuessValid);
                if(_isGuessValid)
                {

				// Convert and Map validated Guesses
                   Guess.GuessBoard = Guess.mapper(
                       _convertPin.PinConverter(localPassableVar),
                       Guess.GuessBoard,
                         out GuessCounter, out _isGuessValid);

				// Generate Hint

					
					
                }
            }
        }


        //Object inicialisations for setting defult values


        private static Solution _solution;
        private static Guess _guess;
        private static Hint _hint;

        internal static Solution Solution { get => _solution; }
        internal static Guess Guess { get => _guess; set => _guess = value; }
        internal static Hint Hint { get => _hint; set => _hint = value; }

        static Board()
        {
            _solution = new Solution();
            _guess = new Guess();
            _hint = new Hint();
            GuessCounter = Row;
        }

        public Board()
        {
            Row = 10;
            Columns = 4;
            IsSessionValid = true;

        }
        public Board(int row, int columns, bool isSessionValid)
        {
            Row = row;
            Columns = columns;
            GuessCounter = row;
            IsSessionValid = isSessionValid;
        }


        internal bool SessionValidator()
        {
            if (GuessCounter < 0)
            {
                IsSessionValid = false;
            }
            else if (GuessCounter <= Row && !(Row - GuessCounter > Row - 1))
            {
                IsSessionValid = true;
            }
			else 
			{
				IsSessionValid = false;
			}
            return IsSessionValid;
        }
    }
}