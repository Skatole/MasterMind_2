using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        private HintPin hintPin;
        private Dictionary<int, GuessColor> memory = new Dictionary<int, GuessColor>();
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }


        public Hint ( )
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
           
        }




        internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution, bool isGuessValid )
        {
            if (isGuessValid)
            {

                HintPin[] rowOfHintPins = new HintPin[solution.Sol.Length];
                // Seed the memory with empty values;
                for (int i = 0; i < solution.Sol.Length; i++)
                {
                    memory.Add(i, new GuessColor());
                    rowOfHintPins[i] = new HintPin( HintColor.None );
                }
                foreach (var item in guess.GuessBoard[Row - GuessCounter].Select((value, i) => new {value, i}))
                {
                    foreach (var sol in solution.Sol.Select((value, i) => new {value, i}))
                    {
                        // System.Console.WriteLine( 
                        //       (item.i == sol.i) + "  indexek : " + " item: " + item.i + " sol.i: " + sol.i 
                        //       + " item.Color vs. sol.Color  " + (item.value.Color == sol.value)
                        //       );  

                        if ((solution.Sol[item.i] == guess.GuessBoard[Row - GuessCounter][item.i].Color) && memory[item.i] != sol.value)
                        {
                            memory[item.i] = sol.value;
                            System.Console.WriteLine("IN RED : " + " MEMORY: " + memory[sol.i]);
                            hintPin = new HintPin( HintColor.InPlace );
                            rowOfHintPins[item.i] = hintPin;
                        }
                        else if (solution.Sol[sol.i] == guess.GuessBoard[ Row - GuessCounter ][item.i].Color && memory[sol.i] != sol.value )
                        {

                            memory[sol.i] = sol.value;
                            System.Console.WriteLine("IN White : " + " MEMORY: " + memory[sol.i]);
                            hintPin = new HintPin( HintColor.In );
                            rowOfHintPins[item.i] = hintPin;
                        }
                    }
                }



                foreach (var item in rowOfHintPins)
                {
                    System.Console.Write(item + " , ");
                }

                _hintBoard[Row - GuessCounter] = rowOfHintPins;
                memory.Clear();

            }

            return _hintBoard;
        }
    }
}