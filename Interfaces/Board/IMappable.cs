using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.Interfaces.Board
{
    internal interface IMappable
    {
        public IConfig Config { get; }
        public IPin Pin { get; set; }
        internal Dictionary<int, Pin[]> Mapper(Pin pin, Dictionary<int, Pin[]> Board);
    }
}
