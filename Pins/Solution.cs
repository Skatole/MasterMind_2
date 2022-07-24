using MasterMind_Project_2.Interfaces;

namespace MasterMind_Project_2
{
    public class Solution : Permutations
    {

        internal GuessPin [ ] Sol { get; set; }

        internal Solution ( IConfig config ) : base(config)
        {
            Sol = new GuessPin[Columns];
            generateSolution();
        }

        private GuessPin [ ] generateSolution ( )
        {

            Console.WriteLine("Solution : \n");
            Random random = new Random((int) DateTime.Now.Ticks);
            int index = random.Next(AllSolutions.Count);

            for (int i = 0; i < AllSolutions[index].Length; i++)
            {
                Sol[i] = new GuessPin(AllSolutions[index][i]);
                System.Console.WriteLine(Sol[i] + " , ");
            }
                        
            System.Console.WriteLine("\n");

            return Sol;
        }
    }
}
