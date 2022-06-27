

using System;
using System.Linq;

namespace MasterMind_Project_2
{
    class Program
    {

        private static void Main(String[] args)
        {

            Board Board = new Board();

            while (Board.SessionValidator())
            { 

                System.Console.WriteLine("Make a Guess:");
                string input = Console.ReadLine();
               



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
