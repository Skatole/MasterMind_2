using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind_Project_2
{
    class Hint : PinMapper
    {
        private HintPin hintPin;
        private List<GuessColor> memory = new List<GuessColor>();
        internal Dictionary<int, HintPin[]>? _hintBoard;
        private Array allPin = Enum.GetValues(typeof(PinColor));
        internal Dictionary<int, HintPin [ ]>? HintBoard { get => _hintBoard; set => _hintBoard = value; }
        // private int _in;
        // private int _inPlace;
        // internal int In {get => _in; set => _in = value; }
        // internal int InPlace { get => _inPlace; set => _inPlace = value; }


        public Hint ( )
        {
            _hintBoard = new Dictionary<int, HintPin [ ]>();
            hintPin = new HintPin();
            _hintBoard = mapper(( HintPin ) hintPin, HintBoard);
        }




        internal Dictionary<int, HintPin [ ]> GenerateHint ( Guess guess, Solution solution )
        {
                HintPin[] rowOfHintPins = new HintPin[guess.GuessBoard [ GuessCounter ].Length];
                // Seed one row of hints with empty pins 
                for ( int i = 0; i < guess.GuessBoard [ GuessCounter ].Length; i++ )
                {
                    rowOfHintPins [ i ] = new HintPin(HintColor.None);
                }
                //Seed memory

                memory = CreateShortTermMemory(solution.Sol);

                foreach ( var item in guess.GuessBoard [ GuessCounter ].Select(( value, i ) => new { value, i }) )
                {
                    if ( guess.GuessBoard [ GuessCounter ] [ item.i ].Color == memory [ item.i ] )
                    {
                        rowOfHintPins [ item.i ] = new HintPin(HintColor.InPlace);
                        memory [ item.i ] = GuessColor.None;
                    }
                }
                foreach ( var item in guess.GuessBoard [ GuessCounter ].Select(( value, i ) => new { value, i }) )
                {
                    foreach ( var sol in solution.Sol.Select(( value, i ) => new { value, i }) )
                    {
                        if ( guess.GuessBoard [ GuessCounter ] [ item.i ].Color == memory [ sol.i ] )
                        {
                            rowOfHintPins [ item.i ] = new HintPin(HintColor.In);
                            memory [ sol.i ] = GuessColor.None;
                        }
                    }
                }
                

                rowOfHintPins = Scramble(rowOfHintPins);

                _hintBoard [ GuessCounter ] = rowOfHintPins;

            return _hintBoard;
        }
    }
}