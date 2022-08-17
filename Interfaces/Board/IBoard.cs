using MasterMind_Project_2.GameBoard;

namespace MasterMind_Project_2.Interfaces.Board
{
    internal interface IBoard
    {
        public Guess Guess { get; }
        public Hint Hint { get; }
        public Solution Solution { get; }
        public bool IsWin { get; set; }
        public bool IsGameOver { get; set; }
        public void Game(string input);
        public bool GameOverDetermination();
        public bool WinnerDetermination();
    }
}
