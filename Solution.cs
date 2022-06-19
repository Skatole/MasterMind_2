using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {
        private List<PinColor> sol = new List<PinColor>();

        public Solution()
        {
            for (int i = 0; i <= 4; i++)
            {
          
                sol.Add(RandomPin.generateRandomPin(1, 0));

                var days = Enum.GetValues(typeof(PinColor))
                        .Cast<PinColor>()
                        .Select(d => (d, (int)d))
                        .ToList();

                sol.Cast<PinColor>().Select(d => (char)d).ToList().ForEach(s => Console.WriteLine(s)) ;
                
            }
        }

        internal List<PinColor> Sol { get => sol; }


        public override string ToString()
        {
            return Enum.GetName(typeof(PinColor), sol);
        }


    }
}
