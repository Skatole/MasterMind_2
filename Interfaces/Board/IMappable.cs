using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces.Board
{
    public interface IMappable
    {
        public IConfig Config { get; }
        public Dictionary<int, IPin[]> AddToBoard();
        public Dictionary<int, IPin[]> AddToBoard( IConvertable input);
    }
}
