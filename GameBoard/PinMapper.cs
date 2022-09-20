using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;
using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;

namespace MasterMind_Project_2.GameBoard
{
    public abstract class PinMapper : Board, IMappable
    {

        public IConfig Config { get; }
        public abstract Dictionary<int, IPin[]> Board { get; set; }
        public abstract Dictionary<int, IPin[]> AddToBoard();
        public abstract Dictionary<int, IPin[]> AddToBoard(IConvertable input);

        internal PinMapper(IConfig config) : base(config)
        {
            Config = config;
        }

    }
}