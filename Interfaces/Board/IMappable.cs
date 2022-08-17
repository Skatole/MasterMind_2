using MasterMind_Project_2.GameBoard.Pins;

namespace MasterMind_Project_2.Interfaces.Board
{
    internal interface IMappable
    {
        public IConfig Config { get; }
        internal Dictionary<int, GuessPin[]> Mapper(GuessPin pin, Dictionary<int, GuessPin[]> Board);
        internal Dictionary<int, HintPin[]> Mapper(HintPin pin, Dictionary<int, HintPin[]> Board);
    }
}
