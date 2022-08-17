using Pastel;

using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Pins;
using MasterMind_Project_2.console_display_classes;
using MasterMind_Project_2.Players;

namespace MasterMind_Project_2.Binders
{
    public class Processor
    {

        private readonly Board _board;
        private readonly Guess _guess;
        private readonly Hint _hint;
        private readonly Solution _solution;
        private readonly Permutations _permutations;
        private readonly IMenu _consoleMenu;
        private readonly ISettings _settings;
        private readonly INavigator _navigator;
        private readonly IUser _user;
        private IConfig _config;

        public Processor(
            IUser user,
            IPlayer player,
            IMaster master,
            INavigator navigator,
            Board Board,
            Guess Guess,
            Hint Hint,
            Solution Solution,
            Permutations Permutations,
            IMenu ConsoleMenu,
            IConfig Config,
            ISettings settings)

        {
            _board = Board;
            _guess = Guess;
            _hint = Hint;
            _solution = Solution;
            _permutations = Permutations;
            _consoleMenu = ConsoleMenu;
            _settings = settings;
            _config = Config;
            _navigator = navigator;
        }

        public void InicialiseProcess()
        {
            DisplayOnConsole.Welcome();
            DecideRole();
            while (_config.IsSessionValid)
            {
                _config = _navigator.Navigate(_user, _consoleMenu, _settings, _config);
                StartGameProcess(_config);
            }
        }
        public void StartGameProcess(IConfig config)
        {
            Board defaultBoard = new Board(config);
            defaultBoard.Permutations = new Permutations(config);
            defaultBoard.Solution = new Solution(config);
            defaultBoard.Guess = new Guess(config);
            defaultBoard.Hint = new Hint(config);
        }

        private void DecideRole(IUser user)
        {
            DisplayOnConsole.DecideRole();
            switch (_user.GiveInput())
            {
                case "1":
                    {
                        _user = (IPlayer) user;
                        break;
                    }
                case "2":
                    {
                        _user = (IPlayer) user;
                        break;
                    }
                default:
                    {
                        Console.WriteLine(" \n Invalid input try again! \n ".Pastel(System.Drawing.Color.DarkRed);
                        DecideRole(user);
                        break;
                    }
            }
        }


    }
}