
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Roles;
using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard
{
    public class Board : IBoard
    {

        //class specific not static varriables
        private int _guessCounter;

        private IConfig Config;
        private IConvertable InputConverter;
        private IPermutable Permutations;

        public IValidatable InputValidator { get; }
        public IGuess Guess { get; }
        public IHint Hint { get; }
        public IMappable Solution { get; }
        public bool IsWin { get; set; }
        public bool IsGameOver { get; set; }
        public int GuessCounter { get => _guessCounter; set => _guessCounter = value; }


        //Object inicialisations for setting defult values
        public Board(IConfig config, IGuess guess, IHint hint, IMappable solution, IPermutable permutation, IValidatable validator, IConvertable converter)
        {
            Guess = guess;
            Hint = hint;
            Solution = solution;
            Config = config;
            Permutations = permutation;
            InputValidator = validator;
            InputConverter = converter;
            GuessCounter = config.Rows - config.Rows;
        }

        public Board(IConfig config)
        {
            Config = config;
        }

        public void Game(IUser user)
        {
            if (Solution.Board[Config.Rows] != null)
            {
                /* Decide what role the user has and call functions accordingly: */
                if (user.GetType() == typeof(IPlayer))
                {
                    PlayerInput(user);
                }

                /* Here now the Autosolver should generate the Guess so the Player can play against the algorithm */
                if (user.GetType() == typeof(IMaster))
                {
                    MasterInput(user);
                }

                if (user.GetType() == typeof(IAI))                                  
                {

                }

                _guessCounter = GameOverDetermination() ? _guessCounter : _guessCounter++;

            }
            else
            {
                if (user.GetType() == typeof(IMaster))
                {
                    AddCustomSolution(user);
                }
                else
                {
                    Solution.AddToBoard();
                }
            }


            //List<GuessPin> convGuess = _config.IsNoneAllowed ?
            //_guess.NoneAllowedConverter(
            //    _guess.CleanAndValidate(input, _config.Columns, out _isGuessValid),
            //    ref _isGuessValid
            //    ) :
            //_guess.NoneNotAllowedConverter(
            //    _guess.CleanAndValidate(input, _config.Columns, out _isGuessValid),
            //ref _isGuessValid
            //);

            //if (_isGuessValid)
            //{
            //    _guess.mapper(convGuess, _guess.Board, ref _guessCounter, ref _isGuessValid);
            //    _hint.GenerateHint(_guess, _solution, ref _guessCounter);
            //    GuessCounter = GameOverDetermination() ? GuessCounter : GuessCounter++;
            //}
        }

        /*
         * Mods
         */

        private void PlayerInput(IUser user)
        {
            InputValidator.Validate(user.Input);
            InputConverter.ConvertGuess(InputValidator);
            if (InputValidator.IsInputValid)
            {
                Guess.AddToBoard(InputConverter);
            }
        }

        private void MasterInput(IUser user)
        {
            InputValidator.Validate(user.Input);
            InputConverter.ConvertGuess(InputValidator);
            if (InputValidator.IsInputValid)
            {
                Hint.AddToBoard(InputConverter);
            }
        }

        private void FullAuto(IUser user)
        {

        }

        private void SemiAuto(IUser user)
        {

        }

            private void AddCustomSolution(IUser user)
            {
                InputValidator.Validate(user.GiveInput());
                InputConverter.ConvertGuess(InputValidator);
                Solution.AddToBoard(InputConverter);
            }
            public bool GameOverDetermination()
            {
                IsGameOver = (_guessCounter >= Config.Rows || WinnerDetermination()) ? true : false;
                return IsGameOver;
            }

            public bool WinnerDetermination()
            {
                IsWin = (Hint.InPlace == Config.Columns) ? true : false;
                return IsWin;
            }



        }
    }