using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2.Pins
{
    public class Permutations : Pin
    {
        internal List<GuessColor[]> AllSolutions { get; set; }
		private static GuessColor[] _allPins = (GuessColor[]) Enum.GetValues(typeof(GuessColor));
        internal int permutationCount = 0;
        public Permutations(IConfig config) : base(config) 
        {
            AllSolutions = new List<GuessColor[]>();
              if (config.IsNoneAllowed)
            {
                StandardPermutation();
            } else
            {
                NoEmptyPinsPermutation();
            }
        }
        

        // Create an array which contains "Column" amount of new GuessPin( GuessColor.NOne ) objects.
        // After iterate through the array


        internal List<GuessColor[]> StandardPermutation()
		{
            int len = _allPins.Length;
            return addPermutation(_allPins, len, Columns);
		}

        internal List<GuessColor[]> NoEmptyPinsPermutation()
        {
            GuessColor[] noNone = new GuessColor[_allPins.Length - 1];
            noNone = Array.FindAll(_allPins, i => i != GuessColor.None );
            int len = noNone.Length;
            return addPermutation(noNone, len, Columns);
        }

        internal List<GuessColor[]> addPermutation( GuessColor[] Pins, int len, int Columns)
        {
            for ( int i = 0; i < (int)Math.Pow(len, Columns); i++)
            {
                AllSolutions.Add(permutationUtility(i, Pins, len, Columns));
            }

            return AllSolutions;
        }

        internal GuessColor[] permutationUtility( int n, GuessColor[] Pins, int len, int Columns)
        {
            GuessColor[] onePermutation = new GuessColor[Columns];
           for ( int i = 0; i < Columns; i++ )
           {
               onePermutation[i] = Pins[ n % len ];
               n /= len;
           }

           return onePermutation;
        }
    }
}