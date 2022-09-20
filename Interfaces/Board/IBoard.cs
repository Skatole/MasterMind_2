using MasterMind_Project_2.GameBoard;

namespace MasterMind_Project_2.Interfaces.Board
{
    public interface IBoard
    {
        public IGuess Guess { get; }
        public IHint Hint { get; }
        public IMappable Solution { get; }
        public bool IsWin { get; set; }
        public bool IsGameOver { get; set; }
        public void Game(IUser user);
        public void AddCustomSolution(IUser user);
        public bool GameOverDetermination();
        public bool WinnerDetermination();
    }
}
