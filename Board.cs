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
        internal string GuessString
        {
            get => _guessString;
            set
            {
                _guessString = value;
                IInputCleaner _guessValidator = Guess;
                IPinConverter _convertPin = Guess;
                var localPassableVar = _guessValidator.CleanAndValidate(_guessString, Columns, Row, ref _isGuessValid);
                if ( _isGuessValid )
                {
                    // Convert and Map validated Guesses
                    Guess.GuessBoard = Guess.mapper(
                        _convertPin.PinConverter(localPassableVar),
                        Guess.GuessBoard,
                          out GuessCounter, ref _isGuessValid);

                    System.Console.WriteLine(" \n GUESSBOARD : ");
                foreach ( var item in Guess.GuessBoard [ Row - GuessCounter ] )
                {
                    System.Console.WriteLine(item.Color);
                }
                    // foreach ( var item in Guess.GuessBoard )
                    // {
                    //     System.Console.WriteLine(item.Key + " : ");

                    //     foreach ( var val in item.Value )
                    //     {
                    //         System.Console.Write("val type: " + val.GetType() + ", val: " + val + ", val.Color type: " + val.Color.GetType() + ", val.Color: " + val.Color + " , ");
                    //     }
                    // }






                    // Generate Hint
                    Hint.GenerateHint(Guess, Solution, IsGuessValid);

					 Console.WriteLine(" \n HintBoard");

                foreach ( var item in Hint.HintBoard )
                {
                    Console.WriteLine(item.Key + " : ");

                    foreach ( var val in item.Value )
                    {
                        Console.Write(val.Color + " , ");
                    }
                }

                    System.Console.WriteLine("\n  GUESSCOUNTER :" + GuessCounter);
                    GuessCounter--;



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

        static Board ( )
        {
            Row = 10;
            Columns = 4;
            _solution = new Solution();
            _guess = new Guess();
            _hint = new Hint();
            GuessCounter = Row;
        }

        public Board ( )
        {
            IsSessionValid = true;
        }
        public Board ( int row, int columns, bool isSessionValid )
        {
            Row = row;
            Columns = columns;
            GuessCounter = row;
            IsSessionValid = isSessionValid;
        }


        internal bool SessionValidator ( )
        {
            if ( GuessCounter < 0 )
            {
                IsSessionValid = false;
            }
            else if ( GuessCounter <= Row && !(Row - GuessCounter > Row - 1) )
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