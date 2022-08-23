using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.GameBoard
{
    public class Solution : Permutations, IMappable
    {

        public override Dictionary<int, IPin[]> Board { get; set; }
        private Random _random = new Random((int)DateTime.Now.Ticks);


        internal Solution(IConfig config) : base(config)
        {
            Board[config.Rounds] = new SolutionPin[config.Columns];
            AddToBoard()
        }

        public override Dictionary<int, IPin[]> AddToBoard()
        {
            Console.WriteLine("Solution: ");
            int index = _random.Next(AllPermutations.Count);

            for (int i = 0; i < AllPermutations[index].Length; i++)
            {
                Board[Config.Rounds][i] = new SolutionPin((PinColor)AllPermutations[index][i]);
                Console.WriteLine(Board[i] + " , ");
            }

            Console.WriteLine("\n");

            return Board;
        }

        public override Dictionary<int, IPin[]> AddToBoard(IConvertable input)
        {
            Board[Config.Rounds] = input.convertedPins;
            return Board;
        }
    }
}
