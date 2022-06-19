

using System;
using System.Linq;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main(String[] args)
        {

            Board Board = new Board(true);

            Console.WriteLine(Board.Columns);

            while (Board.IsSessionValid)
            {
                Solution solution = new Solution();

                var days =  Enum.GetValues(typeof(PinColor))
                        .Cast<PinColor>()
                        .Select(d => (d, (char)d))
                        .ToList();

                Console.WriteLine(String.Join(Environment.NewLine, days));


                foreach (PinColor i in Enum.GetValues(typeof(PinColor)))
                {
                    if (solution.Sol.Contains(i))
                    {

                    Console.WriteLine("CICA");
                    }
                }

                Board.IsSessionValid = false;
            }


        }
    }

}
