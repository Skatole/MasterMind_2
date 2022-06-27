using System;

namespace MasterMind_Project_2
{
    public class Board
    {

        //Class specific variables.
        private int _row;
        private int _columns;
        private bool _isSessionValid;
        private int _guessCounter;
        private string[] _inputOptions = new string[10]
		{
			"B", "C", "R", "G", "Y", "W", "P", "S", "?", "L"
		};



        internal int Row { get => _row; }
        internal int Columns { get => _columns; }
        internal int GuessCounter { get => _guessCounter; }
        public bool IsSessionValid { get => _isSessionValid; set => _isSessionValid = value; }
        internal string[] InputOptions { get => _inputOptions; }


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
		}

        public Board()
        {
            _row = 10;
            _columns = 4;
            _isSessionValid = true;
            _guessCounter = _row;
              
        }
        public Board(int row, int columns, bool isSessionValid)
        {
            _row = row;
            _columns = columns;
            _isSessionValid = isSessionValid;
        }


        internal bool SessionValidator()
        {
            if (_guessCounter < 0) 
            {
                _isSessionValid = false;
            } else if (_guessCounter <= _row)
            {
                _isSessionValid = true;
            } else 
            {
                _isSessionValid = false;
            }
            return _isSessionValid;
        }
    }
}