using System;
using System.Collections.Generic;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {

        private GuessColor[] _sol = new GuessColor[Columns];
        internal GuessColor [ ] Sol { get => _sol; }



        public Solution ( )
        {
            generateSolution();
        }

        private GuessColor [ ] generateSolution ( )
        {

            //Console.WriteLine("Solution : \n");
            Random random = new Random((int) DateTime.Now.Ticks);
            List<GuessColor>  randomPin = RandomPin.generateRandomPins(1, 0, Columns);


            for ( int i = 0; i < Columns; i++ )
            {
                int index = random.Next(randomPin.Count);


                //if NONE is allowed you shoould change the implementation here!!!



                _sol [ i ] = (randomPin [ index ]);

                //Console.Write(_sol [ i ] + " , ");
            }

            //Console.WriteLine("\n");

            return _sol;
        }
    }
}
