using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Pins;

namespace MasterMind_Project_2
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
        private IConfig _config;

        public Processor ( 
            Board Board,
            Guess Guess,
            Hint Hint,
            Solution Solution,
            Permutations Permutations,
            IMenu ConsoleMenu,
            IConfig Config,
            INavigator navigator,
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
            while ( _navigator.Navigate(_consoleMenu, _settings, _config).IsSessionValid )
            {
                if (_navigator.IsCustomGame)
                {
                    _config = _navigator.CustomConfig;
                }
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
        

    }
}