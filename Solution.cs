using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_Project_2
{
    internal class Solution : Pin
    {
        private List<PinColor> _sol = new List<PinColor>();
        internal List<PinColor> Sol { get => _sol; }



        public Solution()
        {
            for (int i = 0; i < 4; i++)
            {
          
                RandomPin.generateRandomPin(1, 0);
                _sol.Add(RandomPin.RPin);

                

        
            }
        
        PinColor test = PinColor.Green;

        System.Console.WriteLine((char) test);

        List<int> testList = new List<int>();

        foreach (var item in Enum.GetValues(typeof(PinColor))) 
        {
            System.Console.WriteLine(item);

            testList.Add((int) item);
        }


        foreach (var item2 in testList)
        {
            System.Console.WriteLine((char) item2);
        }
        }

        /* Lehetőségek:
        A solution list egy Tuplet tartalmaz amely ((PinColor) item, (int) item) típusú. Ezt a random fgv. returnje oldja meg. */



        // public override string ToString()
        // {
        //     return Enum.GetName(typeof(PinColor), _sol);
        // }


    }
}
