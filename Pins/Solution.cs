using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    internal class Solution : Permutations
    {

        internal GuessPin [ ] Sol { get; set; }



        internal Solution ( bool isNoneAllowed ) : base(isNoneAllowed)
        {
            Sol = new GuessPin[Columns];
            generateSolution();
        }

        internal Solution ( int Rows, int Columns, bool isNoneAllowed) : base(Rows, Columns, isNoneAllowed)
        {
            Sol = new GuessPin[Columns];
            generateSolution();
        }

        private GuessPin [ ] generateSolution ( )
        {

            // System.Console.WriteLine(" PERMUTATOINS: ");
            // foreach (var item in AllSolutions)
            // {
            //     System.Console.WriteLine("\n");
            //     foreach (var val in item)
            //     {
            //         System.Console.WriteLine(val + " , ");
            //     }

            //     System.Console.WriteLine("\n");
            // }

            Console.WriteLine("Solution : \n");
            Random random = new Random((int) DateTime.Now.Ticks);
            int index = random.Next(AllSolutions.Count);

            for (int i = 0; i < AllSolutions[index].Length; i++)
            {
                Sol[i] = new GuessPin(AllSolutions[index][i]);
                System.Console.WriteLine(Sol[i] + " , ");
            }
                        

            System.Console.WriteLine("\n");
            // List<GuessColor>  randomPin = RandomPin.generateRandomPins(1, 0, Columns);


            // for ( int i = 0; i < Columns; i++ )
            // {
            //     int index = random.Next(randomPin.Count);


            //     //if NONE is allowed you shoould change the implementation here!!!



            //     Sol [ i ] = (randomPin [ index ]);

            //     Console.Write(Sol [ i ] + " , ");
            // }

            // Console.WriteLine("\n");

            return Sol;
        }
    }
}
