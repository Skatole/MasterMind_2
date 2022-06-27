namespace MasterMind_Project_2
{
    class Guess : PinMapper, I_InputValidator, I_PinConverter
    {

        private Pin _guessPin;
        private Dictionary<int, GuessPin[]> _guessBoard;
        internal Dictionary<int, GuessPin[]> GuessBoard { get => _guessBoard; } 
        private Array allPin = Enum.GetValues(typeof(PinColor));

        

        public Guess()
        {
            _guessBoard = new Dictionary<int, GuessPin[]>();
            _guessPin = new GuessPin();
            _guessBoard =  mapper((GuessPin) _guessPin, _guessBoard);

        }

        internal Dictionary<int, GuessPin[]> guessInput(string guess)
        {
            I_PinConverter.
            var validatedPins = validate.CleanAndValidate(guess, Columns);

           var convertedPins = convert.Converter( validate.CleanAndValidate(guess, Columns))

            return _guessBoard;
        }

        

        // private Dictionary<int, GuessPin[]> initialiseNoneGuessBoard()
        // {
        //     GuessPin[] guessNone = new GuessPin[Columns];

        //     for ( int i = 0; i < Row; i++)
        //     {
        //         for ( int j = 0; j < Columns; j++)
        //         {

        //             guessPin = new GuessPin();
        //             guessNone[j] = (GuessPin) guessPin;
        //         }

        //         _guessBoard.Add(i, guessNone );

        //     }
        //     return GuessBoard;
        // }
    }
}