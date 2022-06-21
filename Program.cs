

using System;
using System.Linq;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main(String[] args)
        {

            Board Board = new Board();

            // Console.WriteLine(Board.Columns);

            while (Board.IsSessionValid)
            {
                Solution solution = new Solution();

                foreach (var item in solution.Sol)
                {
                    System.Console.WriteLine(item);
                }

                // var days =  Enum.GetValues(typeof(PinColor))
                //         .Cast<PinColor>()
                //         .Select(d => (d, (char)d))
                //         .ToList();

                // Console.WriteLine(String.Join(Environment.NewLine, days));




                Board.IsSessionValid = false;
            }


        }
    }

}
