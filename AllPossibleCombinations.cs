namespace MasterMind_Project_2
{
    internal class AllPossibleCombinations : Pin
    {
        internal Dictionary<GuessColor[], int> AllSolutions { get; set; }
		private static GuessColor[] _allPins = (GuessColor[]) Enum.GetValues(typeof(GuessColor));
        internal int permutationCount = 0;

     
     internal AllPossibleCombinations()
     {
     }

        internal AllPossibleCombinations( int Rows, int Columns) : base(Rows, Columns)
        {
        }

        // Create an array which contains "Column" amount of new GuessPin( GuessColor.NOne ) objects.
        // After iterate through the array


        internal Dictionary<GuessColor[], int> Standard()
		{
            System.Console.WriteLine("CICA: ");
            int len = _allPins.Length;
            printCombination(_allPins, len, Columns);

            return AllSolutions;
		}

        internal void printCombination( GuessColor[] allPins, int len, int L)
        {
            for ( int i = 0; i < (int)Math.Pow(len, L); i++)
            {
                combinationUtil(i, allPins, len, L);
            }
        }

        internal void combinationUtil( int n, GuessColor[] allPins, int len, int L)
        {
           for ( int i = 0; i < L; i++ )
           {
               System.Console.WriteLine(allPins[ n % len ]);
               n /= len;
           }
           System.Console.WriteLine("\n");
        }
    }
}