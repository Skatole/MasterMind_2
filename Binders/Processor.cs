using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.GameBoard;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Menu;
using MasterMind_Project_2.Interfaces.Roles;

using Pastel;

namespace MasterMind_Project_2.Binders
{
    public class Processor
    {

        private bool _isSessionValid = false;

        private readonly ISettings _settings;
        private readonly INavigator _navigator;
        private Board _board;
        private IUser _user;
        private IConfig _config;

        public Processor(
            IUser User,
            INavigator Navigator,
            Board Board,
            IConfig Config,
            ISettings settings)

        {
            _board = Board;
            _settings = settings;
            _config = Config;
            _navigator = Navigator;
            _user = User;
        }

        public void InicialiseProcess()
        {
            DisplayOnConsole.Welcome();
            DecideRole();
            while (_isSessionValid)
            {
                _config = _navigator.Navigate(_user, _settings, _config);
                _board = new Board(_config);
                DisplayOnConsole.DisplayBoard(_board.Guess, _board.Hint);
                StartGameProcess();
            }
        }
        public void StartGameProcess()
        {
            while (!_board.IsGameOver)
            {
                DisplayOnConsole.MakeAGuess();
                _board.Game(_user.GiveInput());
            }

            DisplayOnConsole.GameOverDisplay(_board.IsWin, _board.Solution);
        }


        private void DecideRole()
        {
            DisplayOnConsole.DecideRole();
            switch (_user.GiveInput())
            {
                case "1":
                    {
                        _user = (IPlayer)_user;
                        _isSessionValid = true;
                        _user.StartGame();
                        break;
                    }
                case "2":
                    {
                        _user = (IMaster)_user;
                        _isSessionValid = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" \n Invalid input try again! \n ".Pastel(System.Drawing.Color.DarkRed));
                        DecideRole();
                        break;
                    }
            }
        }


    }
}