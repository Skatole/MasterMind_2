using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {

        internal GuessColor [ ] Sol { get; set; }



        public Solution ( )
        {
            Sol = new GuessColor[Columns];
            generateSolution();
        }

        private GuessColor [ ] generateSolution ( )
        {

            // Console.WriteLine("Solution : \n");
            Random random = new Random((int) DateTime.Now.Ticks);
            List<GuessColor>  randomPin = RandomPin.generateRandomPins(1, 0, Columns);


            for ( int i = 0; i < Columns; i++ )
            {
                int index = random.Next(randomPin.Count);


                //if NONE is allowed you shoould change the implementation here!!!



                Sol [ i ] = (randomPin [ index ]);

                // Console.Write(Sol [ i ] + " , ");
            }

            //Console.WriteLine("\n");

            return Sol;
        }
    }
}
