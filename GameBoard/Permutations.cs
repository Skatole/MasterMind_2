using MasterMind_Project_2.GameBoard.Pins;
using MasterMind_Project_2.Enums;
using MasterMind_Project_2.Interfaces;
using MasterMind_Project_2.Interfaces.Board;

namespace MasterMind_Project_2.GameBoard
{
    public abstract class Permutations : PinMapper, IPermutable
    {
        public List<GuessColor[]> AllPermutations { get; set; }
        public GuessColor[] AllPins { get; }

        public Permutations(IConfig config) : base(config)
        {
            AllPins = (GuessColor[])Enum.GetValues(typeof(GuessColor));
            AllPermutations = new List<GuessColor[]>();
            if (config.IsNoneAllowed)
            {
                StandardPermutation();
            }
            else
            {
                NoEmptyPinsPermutation();
            }
        }


        // Create an array which contains "Column" amount of new GuessPin( GuessColor.None ) objects.
        // After iterate through the array


        public List<GuessColor[]> StandardPermutation()
        {
            int len = AllPins.Length;
            return addPermutation(AllPins, len, Config.Columns);
        }

        public List<GuessColor[]> NoEmptyPinsPermutation()
        {
            GuessColor[] noNone = new GuessColor[AllPins.Length - 1];
            noNone = Array.FindAll(AllPins, i => i != GuessColor.None);
            int len = noNone.Length;
            return addPermutation(noNone, len, Config.Columns);
        }

        private List<GuessColor[]> addPermutation(GuessColor[] Pins, int len, int Columns)
        {
            for (int i = 0; i < (int)Math.Pow(len, Columns); i++)
            {
                AllPermutations.Add(permutationUtility(i, Pins, len, Columns));
            }

            return AllPermutations;
        }

        private GuessColor[] permutationUtility(int n, GuessColor[] Pins, int len, int Columns)
        {
            GuessColor[] onePermutation = new GuessColor[Columns];
            for (int i = 0; i < Columns; i++)
            {
                onePermutation[i] = Pins[n % len];
                n /= len;
            }

            return onePermutation;
        }
    }
}