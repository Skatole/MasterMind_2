using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {

        private List<(PinColor Name, char Value)> _sol = new List<(PinColor Name, char Value)>();
        internal List<(PinColor Name, char Value)> Sol { get => _sol; }
		internal Dictionary<(PinColor Name, char Value), int> countedRandomPins = new Dictionary<(PinColor Name, char Value), int>();



        public Solution()
        {
            generateSolution();
        }

        private List<(PinColor Name, char Value)> generateSolution() 
        {
			Random random = new Random((int) DateTime.Now.Ticks);
            List<(PinColor, char)>  randomPin = RandomPin.generateRandomPins(1, 0, Columns);

			for ( int i = 0; i < Columns; i++) 
			{
				int index = random.Next(randomPin.Count);
				if (randomPin[index].Item1 != PinColor.None)
				{
					_sol .Add(randomPin[index]);
				}
			}
            return Sol;
        }
    }
}
