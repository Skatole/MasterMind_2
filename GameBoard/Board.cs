
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard
{
    public class Board : IBoard
    {

        //class specific not static varriables

        private Guess _guess;
        private Hint _hint;
        private readonly Solution _solution;
        private readonly Permutations _permutations;
        private readonly IConfig _config;
        private bool _isGuessValid;
        private int _guessCounter;

        //public Guess Guess { get => _guess; }
        //public Hint Hint { get => _hint; }
        //public Solution Solution { get => _solution; }
        public bool IsWin { get; set; }
        public bool IsGameOver { get; set; }


        //Object inicialisations for setting defult values
        public Board(IConfig config, Guess guess, Hint hint, Solution solution, Permutations permutation)
        {
            _guess = guess;
            _hint = hint;
            _solution = solution;
            _permutations = permutation;
            _config = config;
        }

        public Board(IConfig config)
        {
            _config = config;
        }

        public void Game(string input)
        {
            List<GuessPin> convGuess = _config.IsNoneAllowed ?
            _guess.NoneAllowedConverter(
                _guess.CleanAndValidate(input, _config.Columns, out _isGuessValid),
                ref _isGuessValid
                ) :
            _guess.NoneNotAllowedConverter(
                _guess.CleanAndValidate(input, _config.Columns, out _isGuessValid),
            ref _isGuessValid
            );

            if (_isGuessValid)
            {
                _guess.mapper(convGuess, _guess.GuessBoard, ref _guessCounter, ref _isGuessValid);
                _hint.GenerateHint(_guess, _solution, ref _guessCounter);
                _guessCounter = GameOverDetermination() ? _guessCounter : _guessCounter++;
            }
        }

        public bool GameOverDetermination()
        {
            IsGameOver = (_guessCounter >= _config.Rows || WinnerDetermination()) ? true : false;
            return IsGameOver;
        }

        public bool WinnerDetermination()
        {
            IsWin = (_hint.InPlace == _config.Columns) ? true : false;
            return IsWin;
        }



    }
}