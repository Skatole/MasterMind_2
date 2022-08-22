using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;
using MasterMind_Project_2.Interfaces.Board.Pins;

namespace MasterMind_Project_2.GameBoard
{
    public class Solution : Permutations, ISolution
    {

        public Dictionary<int, IPin[]> SolutionPins { get; set; }
        private Random _random = new Random((int)DateTime.Now.Ticks);


        internal Solution(IConfig config) : base(config)
        {
            SolutionPins = new SolutionPin[config.Columns];
        }

        public override Dictionary<int, IPin[]> AddToBoard()
        {
            Console.WriteLine("Solution: ");
            int index = _random.Next(AllPermutations.Count);

            for (int i = 0; i < AllPermutations[index].Length; i++)
            {
                SolutionPins[i][i] = new SolutionPin((PinColor)AllPermutations[index][i]);
                Console.WriteLine(SolutionPins[i] + " , ");
            }

            Console.WriteLine("\n");

            return SolutionPins;
        }

        public override Dictionary<int, IPin[]> AddToBoard(IConvertable input)
        {
            throw new NotImplementedException();
        }
    }
}
